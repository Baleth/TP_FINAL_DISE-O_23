using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadMaximaScript : MonoBehaviour
{
     float velocidadACambiar;
  GameManager gameManager;
    void Start()
    {
        velocidadACambiar = 60;
        gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "auto") 
        {
           
            gameManager.CambiarVelocidadMaxima(velocidadACambiar);
        }
    }
}
