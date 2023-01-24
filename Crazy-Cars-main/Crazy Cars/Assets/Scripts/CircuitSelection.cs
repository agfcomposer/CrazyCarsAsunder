using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitSelection : MonoBehaviour
{
    public GameObject[] circuits;
    public int selectedCircuit = 0;
    
    public GameObject[] characters;
    public int selectedCharacter = 0;

    private GameController gameController = null;

    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    void Start()
    {
        characters[gameController.characterSelected].SetActive(true);
        circuits[0].SetActive(true);
    }

    public void NextCircuit()
    {
        circuits[selectedCircuit].SetActive(false);
        selectedCircuit = (selectedCircuit + 1) % circuits.Length;
        circuits[selectedCircuit].SetActive(true);
    }
    public void PreviusCircuit()
    {
        circuits[selectedCircuit].SetActive(false);
        selectedCircuit--;
        if (selectedCircuit < 0)
        {
            selectedCircuit += circuits.Length;
        }
        circuits[selectedCircuit].SetActive(true);
    }
    public void NextScene(string scene)
    {
        gameController.circuitSelected = selectedCircuit;
        gameController.controller.CargarEscena(scene);
    }
}

