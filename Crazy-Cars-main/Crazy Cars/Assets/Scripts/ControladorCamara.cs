using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour
{
    [SerializeField] GameObject lookAt;
    [SerializeField] GameObject follow;
    [SerializeField] CinemachineVirtualCamera camara;
    private GameController gameController = null;
    private GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var item in players)
        {
            if (item.activeSelf)
            {               
                camara.LookAt = item.transform;
                camara.Follow = item.transform;
                break;
            }            
        }
       
    }

    // Update is called once per frame
    public void Rotar()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
       
        foreach (var item in players)
        {
            if (item.activeSelf)
            {
                player= item;                        
                break;
            }
        }

        camara.transform.rotation = Quaternion.Euler(0, player.transform.rotation.eulerAngles.y, 0);
    }
}
