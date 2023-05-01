using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    //private Rigidbody rigidBody;
    public float speed = 1f;
    public float upForce = 1.2f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        speed += 0.0001f;
        upForce += 0.000005f;
        transform.position += transform.up * speed * Time.deltaTime;
        transform.position += transform.forward * speed * Time.deltaTime * upForce;
    }
}
