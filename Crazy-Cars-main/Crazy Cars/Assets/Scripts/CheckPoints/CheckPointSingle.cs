using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSingle : MonoBehaviour
{
    private TrackCheckPoints trackCheckpoints;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Checkpoint");
            if (trackCheckpoints.PlayerThoughtCheckpoint(this))            
            {
                Destroy(gameObject);
            }
            
        }
    }

    public void SetTrackCheckpoints (TrackCheckPoints trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints;
    }
}
