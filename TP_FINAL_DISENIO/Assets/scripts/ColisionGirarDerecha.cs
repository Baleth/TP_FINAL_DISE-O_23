using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionGirarDerecha : MonoBehaviour
{
    GameManager manager;
    private void Start()
    {
        manager =FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        manager.QuitarPuntaje(10);
    }
}
