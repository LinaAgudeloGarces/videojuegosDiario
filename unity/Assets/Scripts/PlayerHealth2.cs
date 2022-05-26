using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth2 : MonoBehaviour
{
    public float health = 0f;
    public float maxHealth = 100f;
    public PlayerHelathUI2 playerHealthui;

    //Sonido de cuando muere
    public AudioSource audioMuerte;

    public Animator animator2D;
    int num =0;


    //Código de la victoria y GameOver
    public gameOver codigoGO;
    private void Start()
    {
        codigoGO = GameObject.Find("codigoGOV").GetComponent<gameOver>();
        health = maxHealth;
        playerHealthui.setMaxHealth((int)maxHealth);
    }
    internal void UpdateHealth(float mod)
    {
        health += mod;
        if(health > maxHealth)
        {
            health = maxHealth;
        } else if (health <= 0)
        {
           if(num==0){
                audioMuerte.Play();
                animator2D.Play("manuel_morir");
                num=1;
                
            }
             //Para que espere hasta que acabe animación
            else if(!audioMuerte.isPlaying && num==1){
                Debug.Log("Se acabó");
                codigoGO.muertoJ +=1;
                gameObject.SetActive(false);
            }

            health = 0f;
        }
        playerHealthui.setHealth((int)health);
    }
}
