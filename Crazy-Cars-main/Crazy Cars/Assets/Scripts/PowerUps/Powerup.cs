using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour, IPowerup
{
    public float motorForce=2000f;
    public int getID()
    {
        return (int)PowerupId.MOTORFORCE;
    }

    public float OpenPowerup()
    {
        return motorForce;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
