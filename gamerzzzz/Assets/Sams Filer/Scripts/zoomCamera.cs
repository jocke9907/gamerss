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
    public Transform target2;
    
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float distance;
    Camera camera;

    //private void LateUpdate()
    //{

    //    transform.position = target1.position + offset;
    //}


    private void LateUpdate()
    {
        distance = Mathf.Sqrt((target1.position.x - target2.position.x) * (target1.position.x - target2.position.x) +
            (target1.position.z + 10 - target2.position.z) * (target1.position.z + 10 - target2.position.z));

        if(distance * 1.25f < 35)
        {
            GetComponent<Camera>().fieldOfView = 35;
        }
        else if(distance * 1.25f > 60)
        {
            GetComponent<Camera>().fieldOfView = 60;
        }
        else
        {
            GetComponent<Camera>().fieldOfView = distance * 1.25f;
        }

        //GetComponent<Camera>().fieldOfView= distance*1.25f;
        offset = new Vector3((target1.position.x + target2.position.x) / 2, 40, (target1.position.z + target2.position.z) / 2);

        transform.position = offset;
    }

}
