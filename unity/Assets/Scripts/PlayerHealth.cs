using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 0f;
    public float maxHealth = 100f;
    private void Start()
    {
        health = maxHealth;
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
            Debug.Log("Player respawn");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
