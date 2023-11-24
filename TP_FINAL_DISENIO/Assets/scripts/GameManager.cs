using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float tiempoTranscurrido;
    float tiempoAquitarPuntos;
    float tiempoEntrePuntos;
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
        tiempoAquitarPuntos = 0;  
        tiempoEntrePuntos = 2;
    }

    // Update is called once per frame
    void Update()
    {
        velocidadAuto = controlAuto.getVelocity();
       
        tiempoTranscurrido += Time.deltaTime;
        
        if(velocidadAuto > velocidadMaxima)
        {
            if (tiempoTranscurrido > tiempoAquitarPuntos) 
            {
                QuitarPuntaje(2);
                tiempoAquitarPuntos = tiempoTranscurrido + tiempoEntrePuntos;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="auto") 
        {
            if (puntajeActual < puntajeMinimo) 
            {
                //gano
            }
            else
            {
                //perdio
            }
        }    
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
