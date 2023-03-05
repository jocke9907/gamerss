using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomCamera : MonoBehaviour
{

    //------------------------kamera zoom med mus-------------------


    //private void Update()
    //{
    //    if(Input.GetAxis("Mouse ScrollWheel") > 0)
    //    {
    //        GetComponent<Camera>().fieldOfView--;
    //    }
    //    if (Input.GetAxis("Mouse ScrollWheel") < 0)
    //    {
    //        GetComponent<Camera>().fieldOfView++;
    //    }

    //}
    //--------------------------------------------------------------


    public Transform target1;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void LateUpdate()
    {
        transform.position = target1.position + offset;
    }

}
