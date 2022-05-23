using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuBehaviour : MonoBehaviour
{
    //Para el sonido de los botones
    
    public AudioSource  audioBoton;
    
    public int numberPlayer = 1;

    void Start(){
    }
    public void loadScene(int index)
    {
       SceneManager.LoadScene(index);
    }


   public void loadScreen(GameObject screen)
    {   
        audioBoton.Play();
        var canvas = GameObject.Find("MainCanvas");
        foreach (Transform child in canvas.transform) {
            child.gameObject.SetActive(false);
        }
        screen.SetActive(true);
    }

   public void setNumberPlayer(int players)
    {
        numberPlayer = players;
        
    }
}
