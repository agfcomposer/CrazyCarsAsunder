using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MutearMusica : MonoBehaviour
{
    GameController gameController = null;
    [SerializeField] AudioSource musicaSource;
    [SerializeField] AudioSource sonidoSource;
    public bool sonidoEstado = false;
    public bool musicaEstado = false;

    public void Start()
    {
        RefrescarEstados();
    }

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }


    public void Mutear(bool muteado)
    {
        musicaSource.mute = !musicaSource.mute;
        musicaEstado = false;
    }

    public void MutearSFX(bool muteadoSFX)
    {
        sonidoSource.mute = !sonidoSource.mute;
        sonidoEstado = false;
    }

    public void RefrescarEstados()
    {
        sonidoSource.mute = sonidoEstado;
        musicaSource.mute = musicaEstado;
    }



    /*public void Mutearsonidos(bool muteadosonidos)
    {
        if (muteadosonidos)
        {
            AudioListener.volume = 0;


        }
        else
        {
            AudioListener.volume = 1;
        }
    }



    /*public void FiltroPasoBajo()
    {
            Musicadefondo.GetComponent<AudioLowPassFilter>();
            

    }
    */


}
