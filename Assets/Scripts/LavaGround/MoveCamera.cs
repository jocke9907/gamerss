using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    //private Rigidbody rigidBody;
    public float speed = 1.1f;
    public float upForce = 1.1f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        speed += 0.00018f;
        upForce += 0.000015f;
        transform.position += transform.up * speed * Time.deltaTime;
        transform.position += transform.forward * speed * Time.deltaTime * upForce;
    }
}
