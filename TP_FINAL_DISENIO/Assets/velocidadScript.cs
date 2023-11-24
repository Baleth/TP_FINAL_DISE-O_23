using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class velocidadScript : MonoBehaviour
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

        texto.text = "Velocidad " + gameManager.velocidadAuto;

    }
}
