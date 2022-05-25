using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth2 : MonoBehaviour
{
    public float health = 0f;
    public float maxHealth = 100f;
    public PlayerHelathUI2 playerHealthui;



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
            health = 0f;
            //Debug.Log("Player dead");
            codigoGO.muertoJ +=1;
            gameObject.SetActive(false);
        }
        playerHealthui.setHealth((int)health);
    }
}
