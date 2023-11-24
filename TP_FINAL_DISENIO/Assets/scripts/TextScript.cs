using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    TextMeshProUGUI texto;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
         texto = GetComponent<TextMeshProUGUI>();  
    }

    // Update is called once per frame
    void Update()
    {

        texto.text = "Puntos: " + gameManager.puntajeActual;
        
    }
}
