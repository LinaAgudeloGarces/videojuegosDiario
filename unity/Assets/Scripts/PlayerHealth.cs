using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 0f;
    public float maxHealth = 100f;
    public PlayerHelathUI playerHealthui;
    private void Start()
    {
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
            Debug.Log("Player dead");
            gameObject.SetActive(false);
        }
        playerHealthui.setHealth((int)health);
    }
}
