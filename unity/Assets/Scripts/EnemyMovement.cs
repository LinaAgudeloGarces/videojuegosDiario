using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackDamage = 10f;
    public float attackSpeed = 1f;

    public Animator animator2D;
    private Rigidbody2D rb;
    private PlayerMovement player;
    private Vector3 directionToPlayer;
    private Vector3 localScale;
    private float canAttack;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;
        localScale = transform.localScale;
    }
    private void FixedUpdate()
    {
        moveEnemy();
        

    }

    private void moveEnemy()
    {
        directionToPlayer = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * moveSpeed;
        animator2D.SetFloat("Horizontal", rb.velocity.x);
        animator2D.SetFloat("Vertical", rb.velocity.y);
        animator2D.SetFloat("Speed", rb.velocity.normalized.sqrMagnitude);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            if(attackSpeed <= canAttack)
            {
                //isAttacking = true;
                //animator2D.SetBool("Attacking", isAttacking);
                animator2D.Play("Attack Tree");
                collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                
                canAttack += Time.deltaTime;
            }
        }
    }

}