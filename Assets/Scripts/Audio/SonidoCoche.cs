using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoCoche : MonoBehaviour
{

    AudioSource audioSource;
    public float minimaAltura = 0.5f;
    public float maximaAltura = 1.7f;

    public float engineSpeed = 1f;
        
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = minimaAltura;
    }

    // Update is called once per frame
    void Update()
    {
        if(engineSpeed < minimaAltura)
        {
            audioSource.pitch = minimaAltura;
        } 
        else if (engineSpeed > maximaAltura)
        {
            audioSource.pitch = maximaAltura;
        } 
        else 
        {
            audioSource.pitch = engineSpeed;
        }
        //se limita la velocidad del engine la limitamos a los máximos y mínimos del pitch
    }
}
