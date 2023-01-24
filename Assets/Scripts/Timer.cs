using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] public TMP_Text timerText;
    [SerializeField] private float timerTime;
    [SerializeField] private int countDown = 6;
    [SerializeField] private float countDownSecond = 6f;
    private float elapsedTime;

    private int minutes, seconds, cents;

    private GameController gameController = null;
    
    [SerializeField] Image timer;
    [SerializeField] Sprite[] sprite;
    [SerializeField] GameObject canvas;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] SFX;

    public void cambiarSprite(int indice)
    {
        timer.sprite = sprite[indice];
    }

    public void cambiarSFX (int indiceSFX)
    {
        audioSource.PlayOneShot(SFX[indiceSFX]);
        audioSource.Play();
        Debug.Log(SFX[indiceSFX].name);
    }

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        StartCoroutine(CuentaAtras());
    }

    IEnumerator CuentaAtras()
    {
        //corrutina: función k se empieza a ejecutar. al llegar a yield return se ejecuta cada segundo/momento. tb hay que ejecutarla
        int cuentaAtras = countDown;
        for (int i = 0; i < cuentaAtras; i++)
        {
            //lo que se ejecute aquí se ejecuta 1 vez al segundo hasta que se cumpla la condición
            countDown = countDown - 1;
            if (countDown == 2)
            {
                canvas.SetActive(true);
                //ejecuta sprite + sonido
                cambiarSFX(0);
                cambiarSprite(0);
            }
            if (countDown == 1)
            {
                cambiarSFX(0);
                cambiarSprite(1);
            }
            if (countDown == 0)
            {
                cambiarSFX(1);
                cambiarSprite(2);
                
            }
            timerText.text = countDown.ToString();

           
            yield return new WaitForSeconds(1f);


        }
        canvas.SetActive(false);
    }




    void Update()
    {
        if (countDown < 0)
        {
            //cambiarSprite(2);
            

            gameController.enableCar = true;
            timerTime -= Time.deltaTime;
            elapsedTime += Time.deltaTime;
            minutes = (int)(timerTime / 60f);
            seconds = (int)(timerTime - minutes * 60f);
            cents = (int)((timerTime - (int)timerTime) * 100f);
            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, cents);

            /*if (countDown == 0)
            {
                cambiarSFX(1);
            }
            
            if (elapsedTime > 2)
            {
                canvas.SetActive(false);
            }
            if (timerTime < 0)
            {
                Destroy(this);
            }
              */
        }
        else
        {
            countDownSecond -= Time.deltaTime;
            countDown = Mathf.FloorToInt(countDownSecond);
            seconds = (int)(countDown - minutes * 60f);            
            timerText.text = string.Format("{0:00}",  seconds);
            /*if (countDown < 1)
            {
                cambiarSprite(1);
                cambiarSFX(0);
            }
            else if ( countDown < 2)
            {                
                cambiarSprite(0);
                
                cambiarSFX(0);
            }
            */
            
        }
        
    }
    
}
