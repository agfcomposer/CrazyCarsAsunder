using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishLine : MonoBehaviour
{    
    [SerializeField] PauseController pauseController;

    [SerializeField] GameObject Podio;

    [SerializeField] AudioSource meta;
    [SerializeField] AudioSource jingleMeta;
    [SerializeField] AudioSource musicaFondo;
    [SerializeField] DelayMusica delayMusica;

    private GameController gameController = null;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }


    public IEnumerator DelayJingle()
    {
        yield return new WaitForSeconds(4f);
        meta.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ENTRA");
            //DelayJingle();
            //meta.Play();
            StartCoroutine(DelayJingle());
            jingleMeta.Play();
            musicaFondo.Stop();
            pauseController.isShowing = true;
            pauseController.EnableCanvas();

            //Podio.SetActive(true);

            gameController.enableCar = false;


        }
    }


}

