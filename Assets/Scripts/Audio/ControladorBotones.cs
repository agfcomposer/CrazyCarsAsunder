using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBotones : MonoBehaviour
{
    GameController gameController;

    private void Start()
    {
        //capturar en una variable el game controller
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

    }

    public void Musica(bool muteado)
    {
        gameController.mutearMusica.Mutear(muteado);
    }


    public void Sonidos(bool muteadoSFX)
    {
        gameController.mutearMusica.MutearSFX(muteadoSFX);
    }

    void Volver()
    {

    }
}
