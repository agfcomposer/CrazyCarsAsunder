using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class BarridoFrecuencias : MonoBehaviour
{
    public float thresholdMaximo = 50;
    public AudioMixer mixFiltro;
    public AudioMixerSnapshot[] snapshotsfiltro;
    public float[] weights;
    // Start is called before the first frame update
    void CambioSnapshots()
    {

        mixFiltro.TransitionToSnapshots(snapshotsfiltro, weights, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
