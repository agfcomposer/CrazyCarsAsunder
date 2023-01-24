using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public GameObject plataforma;
    public float rotateSpeed;
    public GameObject player;

    int materialcase = 1;
    public Material material_1;
    public Material material_2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        plataforma.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
    public void cambiarMaterial()
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
    }

}
