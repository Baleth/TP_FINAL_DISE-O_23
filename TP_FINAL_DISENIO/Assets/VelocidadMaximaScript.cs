using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadMaximaScript : MonoBehaviour
{
     float velocidadACambiar;
  GameManager gameManager;
  ControlAuto controlAuto;
    void Start()
    {
        controlAuto = FindAnyObjectByType<ControlAuto>().GetComponent<ControlAuto>();
        gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
            if (controlAuto.getVelocity() > 60)
            {
                gameManager.QuitarPuntaje(10,"velocidad");
            }
        
    }
}
