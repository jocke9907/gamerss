using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementWASD : MonoBehaviour
{
    // Start is called before the first frame update
    float xDirection;
    float zDirection;
    public float speed = 0.5f;
    float rotationSpeed = 720;
    // Update is called once per frame
    void Update()
    {
        //float xDirection = Input.GetAxis("Horizontal");
        //float zDirection = Input.GetAxis("Vertical");

       

        if (Input.GetKey(KeyCode.D))
        {
            xDirection = -1f;
        }
        if (Input.GetKey(KeyCode.G))
        {
            xDirection = 1f;
        }
        if (Input.GetKey(KeyCode.R))
        {
            zDirection = 1f;
        }
        if (Input.GetKey(KeyCode.F))
        {
            zDirection = -1f;
        }
        

        Vector3 movementDirection = new Vector3(xDirection, 0.0f, zDirection);
        movementDirection.Normalize();

        //transform.position += moveDirection * speed;

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        //if (movementDirection != Vector3.zero)
        //{
        //    Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        //}
    }
}
