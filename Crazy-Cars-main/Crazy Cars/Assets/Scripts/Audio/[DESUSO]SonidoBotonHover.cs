using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoBotonHover : MonoBehaviour
{

    [SerializeField] AudioSource fX;
    [SerializeField] AudioClip sobreFX;
    [SerializeField] AudioClip clickFX;
    // Start is called before the first frame update
    public void SobreFX()
    {
        fX.PlayOneShot(sobreFX);
    }

    public void ClickFX()
    {
        fX.PlayOneShot(clickFX);
    }

}


