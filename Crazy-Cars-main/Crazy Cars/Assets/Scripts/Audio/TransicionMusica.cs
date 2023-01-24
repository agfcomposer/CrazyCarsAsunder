using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
public class TransicionMusica : MonoBehaviour
{
    public List<string> nombreEscenas;
    public string M�sicadefondo;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += EscenaCargada;
    }

    void EscenaCargada (Scene scene, LoadSceneMode mode)
    {
        ChecarEscenasDuplicadas();
        ChecarSiEscenaLista();
    }

    void ChecarEscenasDuplicadas()
    {
        TransicionMusica[] collection = FindObjectOfType<TransicionMusica>();
    }
    */


public class TransicionMusica : MonoBehaviour
{
    //nombre de escenas en las que va a estar presente la m�sica
    public List<string> sceneNames;

    //nombre de la instancia para que continue entre escenas
    public string instanceName;

 //en la transici�n se comprueban los objetos presentes para ver si est� la m�sica
    private void Start()
    {
        //no destruye el objeto en la carga en una primera instacia
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //borra objetos duplicados para quedarse con uno y as� no hay duplicaciones de sonido
        CheckForDuplicateInstances();
        //comprueba si el objeto debe eliminarse en funcion de a los nombres dados a la escena
        CheckIfSceneInList();
    }

    void CheckForDuplicateInstances()
    {
        //
        TransicionMusica[] collection = FindObjectsOfType<TransicionMusica>();

        // iterate through the objects with this component, deleting those with matching identifiers
        foreach (TransicionMusica obj in collection)
        {
            if (obj != this) // impide que se borre el objeto que esta sonando
            {
                if (obj.instanceName == instanceName)
                {
                    Debug.Log("Objeto (m�sica) duplicado: se elimina");
                    DestroyImmediate(obj.gameObject);
                }
            }
        }
    }

    void CheckIfSceneInList()
    {
        //comprueba la escena en la que estamos y si est� en la lista
        string currentScene = SceneManager.GetActiveScene().name;

        if (sceneNames.Contains(currentScene))
        {
            //si la escena est�, la mantenemos 
        }
        else
        {
            //si no, destruimos el gameobject
            SceneManager.sceneLoaded -= OnSceneLoaded;
            DestroyImmediate(this.gameObject);
        }
    }
}