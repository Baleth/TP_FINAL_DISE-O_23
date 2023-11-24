using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemaforoScript : MonoBehaviour
{
    
    public string colorActual;
    string colorInicial;
    GameManager gameManagerScript;
    Light[] luces;
    void Start()
    {
        gameManagerScript = FindFirstObjectByType<GameManager>().GetComponent<GameManager>();
        colorActual = "rojo";
        luces = GetComponentsInChildren<Light>();
        StartCoroutine(CambiarLuz());
        Debug.Log(luces);
    }
    IEnumerator CambiarLuz()
    {
        while (true)
        {
            
            colorActual = "rojo";
            luces[0].enabled = true;
            luces[1].enabled = false;
            luces[2].enabled = false;
            Debug.Log(colorActual);
            yield return new WaitForSeconds(5);
            colorActual = "amarillo";
            luces[0].enabled = false;
            luces[1].enabled = true;
            luces[2].enabled = false;
            Debug.Log(colorActual);
            yield return new WaitForSeconds(2);
            colorActual = "verde";
            luces[0].enabled = false;
            luces[1].enabled = false;
            luces[2].enabled = true;
            Debug.Log(colorActual);
            yield return new WaitForSeconds(5);
            colorActual = "amarillo";
            luces[0].enabled = false;
            luces[1].enabled = true;
            luces[2].enabled = false;
            yield return new WaitForSeconds(2);
        }
    }

   
    
}
