using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float tiempoTranscurrido;
    float tiempoAquitarPuntos;
    public float puntajeActual;
    float puntajeMinimo;
    float velocidadMaxima;
    public float velocidadAuto;
    ControlAuto controlAuto;
    void Start()
    {
        controlAuto = FindAnyObjectByType<ControlAuto>().GetComponent<ControlAuto>();
        velocidadMaxima = 90;
        puntajeActual  = 100;
        puntajeMinimo = 40;
        tiempoTranscurrido = 0;
    }

    // Update is called once per frame
    void Update()
    {
        velocidadAuto = controlAuto.getVelocity();
       
        tiempoTranscurrido += Time.deltaTime;    
    }
    private void OnTriggerEnter(Collider other)
    {
        //Termino el recorrido
    }
    public void CambiarVelocidadMaxima(float nuevaVelocidad) 
    {
        velocidadMaxima = nuevaVelocidad;
    }
    public void QuitarPuntaje(float cantidad) 
    {
        puntajeActual -= cantidad; 
    }
}
