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


    void Start()
    {
        //animator2D = GameObject.Find("Enemy").GetComponent<Animator>();
        audioMuerte = GameObject.Find("EnemySpawnZone").GetComponent<AudioSource>();
        codigoGO = GameObject.Find("codigoGOV").GetComponent<gameOver>();
        health = maxHealth;
        
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

            if(num==0){
                audioMuerte.Play();
                gameObject.GetComponent<Animator>().Play("enemigo_morir");
                //animator2D.Play("enemigo_morir");
                num=1;
                
            }
             //Para que espere hasta que acabe animación
            else if(!audioMuerte.isPlaying && num==1){
                Debug.Log("Se acabó");
                codigoGO.muertos +=1;
                gameObject.SetActive(false);
                num=2;
            }

            else if(num==2){
                gameObject.SetActive(false);
            }

            health = 0f;
            
        }
    }

}
