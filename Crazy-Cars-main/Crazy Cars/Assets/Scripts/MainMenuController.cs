using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private GameController gameController = null;
    public float delay = 2f;
    public GameObject canvasCreditos;
    public GameObject canvasMenu;

    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Start()
    {
        if (canvasCreditos != null) { 
            canvasCreditos.SetActive(false);
        }
    }

    // Update is called once per frame
    public void CargarCreditos()
    {
        if (canvasCreditos != null) {
            canvasCreditos.SetActive(true);
        }

        if (canvasMenu != null) {
            canvasMenu.SetActive(false);
        }
    }
    public void CargarMenu()
    {

        if (canvasCreditos != null) {
            canvasCreditos.SetActive(false);
        }

        if (canvasMenu != null) {
            canvasMenu.SetActive(true);
        }
    }

    public void CargarEscena(string nombreEscena)
    {

        gameController.CargarEscena(nombreEscena);
    }

    public void CerrarJuego()
    {
        Application.Quit();
        Debug.Log("Juego Cerrado");
    }
}
