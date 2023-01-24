using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoFX : MonoBehaviour
{

    [SerializeField] AudioClip[] pistas;
    //[SerializeField] AudioClip segundopulso;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayPista(int pista)
    {
        if (pista < pistas.Length ) { 
            audioSource.PlayOneShot(pistas[pista]);
        }
    }

   /* public void Playsegun()
    {
        audioSource.PlayOneShot(segundopulso);
    }
   */
}
