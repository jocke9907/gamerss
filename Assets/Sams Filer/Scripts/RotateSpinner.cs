using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class RotateSpinner : MonoBehaviour
{
    //---------------SCRIPT WRITTEN BY SAM----------------------------

    //this script makes the spinner objects in the minigame "wheelspinner" rotate faster and faster around its centerpoint.
    // It does this by multiplaying a very slow acceleration to deltatime 60 times a second.
    // while also having a minimum and maximum acceleration speed.


    public float rotationSpeed = 10f; 
    public float acceleration = 0.1f; 


    private void OnTriggerEnter(Collider other)
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, rotationSpeed, 0, Space.World);
        if (rotationSpeed > 1.6f)
        {
            rotationSpeed = 1.75f;
        }
        else if(rotationSpeed < -1.6f)
        {
            rotationSpeed = -1.75f;
        }
        else
        {
            rotationSpeed += acceleration * Time.deltaTime;

        }
       

       
    }
}
