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
    private GameObject [] players;
    private GameObject player;
    private Vector3 directionToPlayer1;
    private Vector3 directionToPlayer2;
    private Vector3 directionToPlayer;
    private Vector3 localScale;
    private float canAttack;

    //Audio golpe
    public AudioSource audioGolpe;

    void Start()
    {
        audioGolpe = GameObject.Find("sonidoGolpeE").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        
        
        localScale = transform.localScale;

    }
    private void FixedUpdate()
    {
        
        players = GameObject.FindGameObjectsWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(players.Length);
        if (players.Length == 2)
        {
            directionToPlayer1 = (players[0].transform.position - transform.position);
            directionToPlayer2 = (players[1].transform.position - transform.position);


            if (directionToPlayer1.sqrMagnitude < directionToPlayer2.sqrMagnitude)
            {
                player = players[0];
            }
            else if (directionToPlayer2.sqrMagnitude < directionToPlayer1.sqrMagnitude)
            {
                player = players[1];
            }
        }
        
        
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
                
                animator2D.Play("Attack Tree");
                //Audio del golpe
                audioGolpe.Play();
                //Detecto cuál de los dos es
                Debug.Log(collision.gameObject.name);
                if(collision.gameObject.name=="Luisa")
                {
                    collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                }

                else if(collision.gameObject.name=="Manuel")
                {
                    collision.gameObject.GetComponent<PlayerHealth2>().UpdateHealth(-attackDamage);
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