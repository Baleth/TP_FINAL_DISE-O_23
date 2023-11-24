using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PararScript : MonoBehaviour
{
     bool activado;
    void Start()
    {
        activado = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "auto") 
        {

            StartCoroutine(Activar());
        }
    }
    IEnumerator Activar() 
    {
        activado = true;
        yield return new WaitForSeconds(10);
        activado = false;
    }
}
