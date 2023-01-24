using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{
    public void noKinematico()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic= false;
    }
}
