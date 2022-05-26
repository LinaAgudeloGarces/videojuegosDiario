using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float health = 0f;
    public float maxHealth = 500f;
    public BossHealthUI bossUI;
    public GameObject pantallaVict;
    
    //Audio muertes
    public AudioSource audioMuerte;

    //Sonido Victoria

    public AudioSource audioVictoria;

    //Codigo de movimiento
    public EnemyMovement codigoMovimiento;

    //Animacion muerte
    public Animator animator2D;
    public int num =0;


    void Start()
    {
        
        health = maxHealth;
        bossUI.setMaxHealth((int)maxHealth);
        codigoMovimiento = gameObject.GetComponent<EnemyMovement>();
        animator2D = gameObject.GetComponent<Animator>();
        audioMuerte = gameObject.GetComponent<AudioSource>();
    }
    internal void UpdateHealth(float mod)
    {
        health += mod;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0)
        {
            health = 0f;
            //Se murió
            
        }
        bossUI.setHealth((int)health);
    }

    void Update(){
        if (health == 0f){
            if(num==0){
                codigoMovimiento.moveSpeed=0f;
                animator2D.Play("boss_morir");
                audioMuerte.Play();
                num=1; 
                gameObject.GetComponent<CapsuleCollider2D>().enabled=false;
            }
            else if(num==1 && !audioMuerte.isPlaying){
                Debug.Log("Se acabó");
                gameObject.SetActive(false);
                bossUI.gameObject.SetActive(false);
                pantallaVict.SetActive(true);
                Debug.Log("Ya sono");
                audioVictoria.Play();
            }
        }
               
    }


}
