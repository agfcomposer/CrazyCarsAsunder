using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public  GameController controller;
    //public RealCarController car;

    public  int characterSelected = 0;
    public  int circuitSelected = 0;
    [SerializeField] public MutearMusica mutearMusica;
    [SerializeField] public CambiosBotones cambiobotones;
    [SerializeField] public SonidoFX sonidoFX;
    [SerializeField] public CambiosBotones cambiosBotones;
    [SerializeField] public bool enableCar = false;
    [SerializeField] Dictionary <int,RealCarController> coleccionCoches = new Dictionary<int,RealCarController>();

   private void Awake()
    {
                
        if (controller == null)
        {
            controller = this;
            DontDestroyOnLoad(gameObject);            
        }
        else if (controller != this)
        {
            Destroy(gameObject);            
        }
    }
    public void CargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);       
    }



}
