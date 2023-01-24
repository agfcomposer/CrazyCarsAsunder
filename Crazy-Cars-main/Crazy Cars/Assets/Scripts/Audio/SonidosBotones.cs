using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosBotones : MonoBehaviour
{
    SonidoFX sonidofx;

    CambiosBotones cambioBotones;
   

    void Start()
    {
        sonidofx = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().sonidoFX;
        //trae el sonidoFX en cada escena
    }

    public void ReproducirSFX(int pista)
    {
        sonidofx.PlayPista(pista);
    }

    void Update()
    {
        
    }
}
