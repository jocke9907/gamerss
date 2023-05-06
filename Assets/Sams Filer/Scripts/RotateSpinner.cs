using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class RotateSpinner : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 10f; // initial rotation speed
    public float acceleration = 0.1f; // rate of acceleration


    private void OnTriggerEnter(Collider other)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        // rotate the parent object around its own Y-axis
        //transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        transform.Rotate(0, rotationSpeed, 0, Space.World);


        // increase the rotation speed by the acceleration rate
        rotationSpeed += acceleration * Time.deltaTime;

       
    }
}
