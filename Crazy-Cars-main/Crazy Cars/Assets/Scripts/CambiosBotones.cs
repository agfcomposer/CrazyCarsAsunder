using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CambiosBotones : MonoBehaviour


{
    public Image originalMus;
    public Sprite nuevoSpriteMus;
    public Sprite viejoSpriteMus;
    private bool esOriginal = true;

    public Image originalSFX;
    public Sprite nuevoSpriteSFX;
    public Sprite viejoSpriteSFX;
    private bool esOriginalSFX = true;

    GameController gameController;
    private void Awake()
    {
        //capturar en una variable el game controller
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

    }
    // Start is called before the first frame update

    void Start()
    {
        viejoSpriteMus = originalMus.sprite;
        viejoSpriteSFX = originalSFX.sprite;
    }
    public void NuevaImagen()
    {
        if (esOriginal == true)
        {
            originalMus.sprite = nuevoSpriteMus;
            esOriginal = false;
        }
        else
        {
            originalMus.sprite = viejoSpriteMus;
            esOriginal = true;
        }
    }

    public void NuevaImagenSFX()
    {
            if (esOriginalSFX == true)
            {
                originalSFX.sprite = nuevoSpriteSFX;
                esOriginalSFX = false;
            }
            else
            {
                originalSFX.sprite = viejoSpriteSFX;
                esOriginalSFX = true;
            }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
