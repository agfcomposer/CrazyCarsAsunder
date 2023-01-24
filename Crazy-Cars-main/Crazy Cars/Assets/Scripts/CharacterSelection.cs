using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject plataforma;
    public float rotateSpeed;
    //public GameObject player;

    /*int materialcase = 1;
    public Material material_1;
    public Material material_2;*/
    public GameObject[] characters;
    public int selectedCharacter = 0;
   [SerializeField] CambiarEstadisticasCoche cambiarEstadisticasCoche;

    private GameController gameController = null;
    // Start is called before the first frame update
    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        plataforma.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
    public void NextChacacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) %  characters.Length;
        characters[selectedCharacter].SetActive(true);
        cambiarEstadisticasCoche.cambiarSprite(selectedCharacter);
    }
    public void PreviusChacacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }                
        characters[selectedCharacter].SetActive(true);
        cambiarEstadisticasCoche.cambiarSprite(selectedCharacter);
    }
    public void SelectCharacter()
    {                
        gameController.characterSelected = selectedCharacter;
        Debug.Log(selectedCharacter);
    }
    /*public void cambiarMaterial()
    {
        if (materialcase == 1) materialcase = 2;
        else materialcase = 1;
        {

        }
        Renderer rend = player.GetComponent<Renderer>();
        switch (materialcase)
        {
            case 2:
                rend.material = material_2;
                break;
            case 1:
                rend.material = material_1;
                break;
            default:
                break;
        }
    }*/
}
