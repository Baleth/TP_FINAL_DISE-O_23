using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionSemaforo : MonoBehaviour
{
    GameManager gameManager;
  SemaforoScript semaforoScript;
    void Start()
    {
       gameManager =FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
       semaforoScript = GetComponentInChildren< SemaforoScript>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (semaforoScript.colorActual == "rojo") 
        {
          
            gameManager.QuitarPuntaje(10);

            Debug.Log(" Pase en rojo"+gameManager.puntajeActual);
        }
    }
}
