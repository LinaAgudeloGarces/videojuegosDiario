using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float health = 0f;
    public float maxHealth = 500f;
    public BossHealthUI bossUI;
    public GameObject pantallaVict;



    void Start()
    {
        
        health = maxHealth;
        bossUI.setMaxHealth((int)maxHealth);
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
            bossUI.gameObject.SetActive(false);
            pantallaVict.SetActive(true);
        }
        bossUI.setHealth((int)health);
    }

}
