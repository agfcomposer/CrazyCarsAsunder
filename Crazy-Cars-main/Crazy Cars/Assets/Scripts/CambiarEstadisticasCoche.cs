using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarEstadisticasCoche : MonoBehaviour
{
    [SerializeField] Image estadisticasdCoche;
    [SerializeField] Sprite[] sprite;

    public void cambiarSprite (int indice)
    {
        estadisticasdCoche.sprite = sprite[indice];
    }

}
