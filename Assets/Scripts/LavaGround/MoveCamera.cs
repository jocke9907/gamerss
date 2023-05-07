using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    //private Rigidbody rigidBody;
    public float speed = 1.7f;
    float forwardForce = 2.6f;
    float upForce = 1.9f;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        speed += 0.0001f;
        //upForce += 0.000015f;
        transform.position += transform.up * speed * Time.deltaTime *upForce;
        transform.position += transform.forward * speed * Time.deltaTime * forwardForce;
    }
}
