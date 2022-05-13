using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator2D.SetFloat("Speed", movement.normalized.sqrMagnitude);
        if (movement.sqrMagnitude > 0)
        {
            animator2D.SetFloat("Horizontal", movement.x);
            animator2D.SetFloat("Vertical", movement.y);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Debug.Log("Attack");
            isAttacking = true;
            animator2D.Play("Attack Tree");
        }
        else
        {
            isAttacking = false;
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
                Debug.Log("Attacked Enemy");
                collision.gameObject.GetComponent<EnemyHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }


}
