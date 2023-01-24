using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    private Canvas CanvasMenu;
    public bool isShowing = false;
    public ControladorCamara  camara;

    private GameController gameController = null ;

    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    void Start()
    {
        CanvasMenu = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<Canvas>();
        if (isShowing == false)
        {
            CanvasMenu.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            EnableCanvas(); 
        }
        //camara.Rotar();
    }
    public void ReturnToMain()
    {
        gameController.controller.CargarEscena("MenuPrincipal");        
    }
    public void ResumeGame()
    {

        Time.timeScale = 1;
        CanvasMenu.enabled = false;
        isShowing = false;
    }
    public void Restart()
    { 
        CanvasMenu.enabled = false;       
    }
    public void EnableCanvas()
    {
        Time.timeScale = 0;
        CanvasMenu.enabled = true; 
        isShowing = !isShowing;        
    }
}
