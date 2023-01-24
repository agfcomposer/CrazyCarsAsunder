using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobadorBotones : MonoBehaviour
{
    CambiosBotones cambiosBotones;
    // Start is called before the first frame update
    void Start()
    {
        cambiosBotones = GameObject.FindGameObjectWithTag("GameController").GetComponent<CambiosBotones>();
    }

    // Update is called once per frame
    void Chekar()
    {

    }
}
