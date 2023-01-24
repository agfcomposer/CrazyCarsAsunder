using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirarTronco : MonoBehaviour
{

    [SerializeField] public Rigidbody tronco;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {          
            tronco.isKinematic = false;
        }
    }
}
