using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float puntajeActual;
    float puntajeMinimo;
    float velocidadMaxima;
    public float velocidadAuto;
    ControlAuto controlAuto;
    alertaScript alertaScript;
    void Start()
    {
        controlAuto = FindAnyObjectByType<ControlAuto>().GetComponent<ControlAuto>();
        alertaScript = FindAnyObjectByType<alertaScript>().GetComponent<alertaScript>();
        velocidadMaxima = 90;
        puntajeActual = 100;
        puntajeMinimo = 60;

    }

    // Update is called once per frame
    void Update()
    {
        velocidadAuto = controlAuto.getVelocity();


    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("actual: "+ puntajeActual + " minimo: "+ puntajeMinimo);
        
            if (puntajeActual < puntajeMinimo)
            {
            StartCoroutine( alertaScript.CambiarTexto("aprobo"));
            }
            else
            {
            StartCoroutine(alertaScript.CambiarTexto("desaprobo"));
        }
        
    }
    public void CambiarVelocidadMaxima(float nuevaVelocidad)
    {
        velocidadMaxima = nuevaVelocidad;
    }
    public void QuitarPuntaje(float cantidad, string clave)
    {
        StartCoroutine(alertaScript.CambiarTexto(clave));
        puntajeActual -= cantidad;
        StartCoroutine(controlAuto.Detener());
    }

}
