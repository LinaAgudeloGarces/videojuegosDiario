using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    public Animator animator2D;
    public float attackDamage = 50f;
    public float attackSpeed = .5f;
    private bool isAttacking = false;
    private float canAttack;

    Vector2 movement;
    void Update()
    {
        
        movement.x = Input.GetAxisRaw("Horizontal2");
        movement.y = Input.GetAxisRaw("Vertical2");
        animator2D.SetFloat("Speed", movement.normalized.sqrMagnitude);
        if (movement.sqrMagnitude > 0)
        {
            animator2D.SetFloat("Horizontal2", movement.x);
            animator2D.SetFloat("Vertical2", movement.y);
        }
        if (Input.GetButtonUp("Fire2"))
        {
            //Debug.Log("Attack");
            isAttacking = true;
            animator2D.Play("Attack Tree");
        }
        else
        {
            isAttacking = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }
    void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
 
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            if ((attackSpeed <= canAttack) && isAttacking)
            {
                //Debug.Log("Attacked Enemy");
                try
                {

                collision.gameObject.GetComponent<EnemyHealth>().UpdateHealth(-attackDamage);
                } catch
                {
                    Debug.Log("ataque boss");
                    collision.gameObject.GetComponent<BossHealth>().UpdateHealth(-attackDamage);
                }
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }


}
