using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusHealth : MonoBehaviour
{
    public int health = 40;
    //Sonido
    public AudioSource audioCorazon;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioCorazon.Play();
            try
            {
                collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(health);
            } catch
            {
                collision.gameObject.GetComponent<PlayerHealth2>().UpdateHealth(health);
            }
            
            
            gameObject.SetActive(false);
        }
    }

}
