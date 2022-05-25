using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class introVideo : MonoBehaviour
{

    //Video intro
    public VideoPlayer videointro;

    //Escena a la que se vuelve a cargar
    public string nombreEscena;

    // variable para comprobar que no esté en pausa
    // 0 es no 1 es si
    public int pausa;

    
    //TODO LO QUE SIGUE ES NECESARIO PARA QUE NO LLEVE DE UNA ALA OTRA PANTALLA
    //contador de segundos
    float secondsCounter=0;
    
    //Segundos a contar
    float secondsToCount=5;
    
    // Start is called before the first frame update
    void Start()
    {   
        //indico que se encuentra en pausa
        pausa = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        secondsCounter += Time.deltaTime;
        if (secondsCounter >= secondsToCount)
        {
            secondsCounter=0;
            Debug.Log("Ya pasó el tiempo");
            //Indico que ya puedo decir que el video no se está reproduciendo
            pausa = 0;
        }

        Debug.Log(pausa);
        if(!videointro.isPlaying && pausa==0){
            SceneManager.LoadScene(nombreEscena);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }
}
