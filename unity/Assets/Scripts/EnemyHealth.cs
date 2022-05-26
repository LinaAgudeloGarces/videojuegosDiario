using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 0f;
    public float maxHealth = 100f;

    //Código de la victoria y GameOver
    public gameOver codigoGO;

    //Audio muertes
    public AudioSource audioMuerte;

    //Animacion muerte
    public Animator animator2D;
    int num =0;

    //Codigo movimiento
    public EnemyMovement codigoMovimiento;

    

    void Start()
    {
        animator2D = gameObject.GetComponent<Animator>();
        audioMuerte = gameObject.GetComponent<AudioSource>();
        codigoGO = GameObject.Find("codigoGOV").GetComponent<gameOver>();
        codigoMovimiento = gameObject.GetComponent<EnemyMovement>();
        health = maxHealth;
        
    }
    internal void UpdateHealth(float mod)
    {
        Debug.Log(health);
        health += mod;
        if (health > maxHealth)
        {
            health = maxHealth;
           
        }
        else if (health <= 0)
        {
            health = 0f;
            
            
            
            
        }
    }

    void Update(){
        if (health == 0f){
            if(num==0){
                codigoMovimiento.moveSpeed=0f;
                animator2D.Play("enemigo_morir");
                audioMuerte.Play();
                num=1; 
                gameObject.GetComponent<CapsuleCollider2D>().enabled=false;
            }
            else if(num==1 && !audioMuerte.isPlaying){
                Debug.Log("Se acabó");
                codigoGO.muertos +=1;
                gameObject.SetActive(false);
            }
        }
               
    }


}
