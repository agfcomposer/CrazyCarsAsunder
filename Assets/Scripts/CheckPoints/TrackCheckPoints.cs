 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckPoints : MonoBehaviour
{
    private List<CheckPointSingle> checkPointSingleList;
    private int nextCheckpointSingleIndex;
    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");
        checkPointSingleList = new List<CheckPointSingle>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform) 
        {
                         
            CheckPointSingle checkPointSingle = checkpointSingleTransform.GetComponent<CheckPointSingle>();
            checkPointSingle.SetTrackCheckpoints(this);

            checkPointSingleList.Add(checkPointSingle);
            nextCheckpointSingleIndex = 0;
        }
    }
    public bool PlayerThoughtCheckpoint(CheckPointSingle checkPointSingle)
    {
        
        if (checkPointSingleList.IndexOf(checkPointSingle) == nextCheckpointSingleIndex)
        {
           
            Debug.Log("Bien");
            nextCheckpointSingleIndex++;
            return true;
        }
        else
        {
            Debug.Log("Mal");
            return false;
        }

    }        
}
 