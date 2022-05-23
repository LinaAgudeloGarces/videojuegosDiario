using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 0f;
    public float maxHealth = 100f;

    //Código de la victoria y GameOver
    public gameOver codigoGO;


    void Start()
    {
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
            health = 0f;
            
            gameObject.SetActive(false);
            
            Debug.Log("Enemy dead");
            codigoGO.muertos +=1;
        }
    }

}
