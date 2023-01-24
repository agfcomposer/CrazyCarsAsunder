using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayMusica : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    public float delay = 6;

    /*void PlayDelayed (float delay)
    {
        audiosource.PlayDelayed(6);
    }*/

    // Update is called once per frame
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("PlayAudio", 4.5f);
    }

    void PlayAudio()
    {
        audioSource.Play();
    }



}



