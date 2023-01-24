using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealCarEffects : MonoBehaviour
{
    public AudioSource derrape ;
    public TrailRenderer[] tireMarks ;
    [SerializeField] public GameObject frenoIzq ;
    [SerializeField] public GameObject frenoDer ;
    //private inputManager IM;
    private bool tireMarkFlag ;
    private const string HORIZONTAL = "Horizontal" ;
    private const string VERTICAL = "Vertical" ;
    private float horizontalInput ;
    private float verticalInput ;
    public void Start()
    {  
        frenoIzq.gameObject.SetActive ( false ) ;
        frenoDer.gameObject.SetActive ( false ) ;
    }

    private void FixedUpdate()
    {
        checkDrift();
        GetInput();
    }
    
    private void checkDrift()
    {
        /*if (Input.GetAxis("Vertical") < 0) startEmitter();
        else stopEmitter();*/

    } 
    private void startEmitter()
    {
        if (tireMarkFlag) return;
        foreach (TrailRenderer T in tireMarks)
        {
            T.emitting = true;
            derrape.Play();
        }
        tireMarkFlag = true;
    }
    private void stopEmitter()
    {
        if (!tireMarkFlag) return;
        foreach (TrailRenderer T in tireMarks)
        {
            T.emitting = false;
            derrape.Stop();
        }
        tireMarkFlag = false;
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        
        if (verticalInput < 0)
        {
            frenoIzq.gameObject.active = true;
            frenoDer.gameObject.active = true;
        }
        else
        {
            frenoIzq.gameObject.active = false;
            frenoDer.gameObject.active = true;
        }
    }
}
