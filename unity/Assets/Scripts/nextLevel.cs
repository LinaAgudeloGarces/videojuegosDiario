using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class nextLevel : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            gameOver obj= GameObject.Find("codigoGOV").GetComponent<gameOver>();
            if(obj.numjugador == 1)
            {
                SceneManager.LoadScene(4);
            }else if (obj.numjugador == 2)
            {
                SceneManager.LoadScene(5);
            }
        }
    }
}
