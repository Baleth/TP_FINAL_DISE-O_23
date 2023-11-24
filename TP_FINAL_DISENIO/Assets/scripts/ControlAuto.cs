
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlAuto : MonoBehaviour
{
   
    private Touch touch;
    [System.Serializable]
    public class infoEje
    {
        public WheelCollider ruedaIzquierda;
        public WheelCollider ruedaDerecha;
        public bool motor;
        public bool direccion;

    }
    public List<infoEje> infoEjes;
    public float maxMotorTorsion;
    public float maxAnguloDeGiro;
    public float velocity;
    //Los collider
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    Rigidbody body;
    private void Start()
    {


        body = GetComponent<Rigidbody>();
    }
    void posRuedas(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }
        Transform ruedaVisual = collider.transform.GetChild(0);
        Vector3 posicion;
        Quaternion rotacion;
        collider.GetWorldPose(out posicion, out rotacion);
        ruedaVisual.transform.position = posicion;
        ruedaVisual.transform.rotation = rotacion;

    }
    void toqueFrenar()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && touch.position.y < Screen.height / 2)
            {
                frontLeftWheelCollider.brakeTorque = 150000;
                frontRightWheelCollider.brakeTorque = 150000;
                rearLeftWheelCollider.brakeTorque = 150000;
                rearRightWheelCollider.brakeTorque = 150000;
            }

            if (touch.phase == TouchPhase.Ended && touch.position.y < Screen.height / 2)
            {
                frontLeftWheelCollider.brakeTorque = 0;
                frontRightWheelCollider.brakeTorque = 0;
                rearLeftWheelCollider.brakeTorque = 0;
                rearRightWheelCollider.brakeTorque = 0;
            }
        }


    }
    void toqueAcelerar()
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && touch.position.y > Screen.height / 2)
            {
                frontLeftWheelCollider.motorTorque = maxMotorTorsion;
                frontRightWheelCollider.motorTorque = maxMotorTorsion;
                rearLeftWheelCollider.motorTorque = maxMotorTorsion;
                rearRightWheelCollider.motorTorque = maxMotorTorsion;
            }

            if (touch.phase == TouchPhase.Ended && touch.position.y > Screen.height / 2)
            {
                frontLeftWheelCollider.motorTorque = 0;
                frontRightWheelCollider.motorTorque = 0;
                rearLeftWheelCollider.motorTorque = 0;
                rearRightWheelCollider.motorTorque = 0;
            }
          }
        }   
    
   
    private void FixedUpdate()
    {
        toqueAcelerar();
        toqueFrenar();
        velocity =Mathf.Round((Mathf.Sqrt(Mathf.Pow(body.velocity.x, 2) + Mathf.Pow(body.velocity.z, 2))*6));
       // ControlarFrenado();

        //float motor = maxMotorTorsion * Input.GetAxis("Vertical");
        // float direccion = maxAnguloDeGiro * Input.GetAxis("Horizontal");


        //float motor = maxMotorTorsion * Input.acceleration.y*-1;
        //float motor = 0;
        //if (band == true)
        //{
        //    motor = maxMotorTorsion * 1;
        //}
        //else {
        //    motor = 0;
        //}
        //if (fren == true)
        //{
        //    motor = -2000;
        //}

        float direccion = maxAnguloDeGiro * Input.acceleration.x;
        foreach (infoEje ejesInfo in infoEjes)
        {
            //paraGirar las ruedas
            if (ejesInfo.direccion)
            {
                ejesInfo.ruedaIzquierda.steerAngle = direccion;
                ejesInfo.ruedaDerecha.steerAngle = direccion;
            }
            //Mover las ruedas
            //if (ejesInfo.motor)
            //{
            //    ejesInfo.ruedaIzquierda.motorTorque = motor;
            //    ejesInfo.ruedaDerecha.motorTorque = motor;
            //}
            posRuedas(ejesInfo.ruedaIzquierda);
            posRuedas(ejesInfo.ruedaDerecha);

        }

    }

    

    public void Presiono()
    {
        Debug.Log("Estoy presionando");
    }
    public void deje()
    {
        Debug.Log("Deje de presionar");
    }
    public float getVelocity() 
    {
        return velocity;
    }
}
