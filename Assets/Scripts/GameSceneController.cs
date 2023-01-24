using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;

    private GameController gameController = null;
    
    

    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }

        characters[gameController.characterSelected].SetActive(true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
