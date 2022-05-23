using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{
    //Contador de enmigos muertos
    public int muertos;

    //Contador de jugadores muertos

    public int muertoJ;
    public GameObject pantallaGO;
    public GameObject pantallaVict;

    //Para saber numero de jugadores
    public int numjugador;
    // Start is called before the first frame update
    void Start()
    {
        muertos=0;
        muertoJ=0;
        pantallaGO.SetActive(false);
        pantallaVict.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(muertos);
        if(muertos==3){
            Debug.Log("Lo lograste");
            pantallaVict.SetActive(true);
        }
        //Aqui se podría comprobar lo de dos jugadores
        else if(numjugador==1){
            if(muertoJ==1){
                        Debug.Log("Perdiste");
                        pantallaGO.SetActive(true);
             }
        }
        else if(numjugador==2){
            if(muertoJ==2){
                        Debug.Log("Perdiste");
                        pantallaGO.SetActive(true);
             }
        }
    }
}
