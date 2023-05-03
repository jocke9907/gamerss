using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLava : MonoBehaviour
{
    //private Rigidbody rigidBody;
    public float lavaSpeed = 1f;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lavaSpeed += 0.0001f;
        transform.position += transform.up * lavaSpeed * Time.deltaTime;
        transform.position += transform.forward * lavaSpeed * Time.deltaTime *2.7f ;
    }
}
