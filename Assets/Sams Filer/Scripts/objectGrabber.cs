using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectGrabber : MonoBehaviour
{

    //public KeyCode grabButton;
    //public float grabDistance = 1.5f;

    //private bool isGrabbing = false;
    //private GameObject grabbedObject = null;




    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(grabButton))
    //    {
    //        if (isGrabbing)
    //        {
    //            ReleaseObject();
    //        }
    //        else
    //        {
    //            MoveObject();
    //        }
    //    }
    //}

    //void GrabObject()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position,transform.forward, out hit, grabDistance))
    //    {
    //        if (hit.collider.gameObject.GetComponent<Rigidbody>() != null)
    //        {
    //            grabbedObject = hit.collider.gameObject;
    //            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
    //            isGrabbing = true;
    //        }
    //    }
    //}

    //void MoveObject()
    //{
    //    grabbedObject.transform.position = transform.position + transform.forward * grabDistance;
    //}

    //void ReleaseObject()
    //{
    //    grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
    //    grabbedObject = null;
    //    isGrabbing = false;
    //}
    public float maxGrabDistance = 0.5f;
    public KeyCode grabButton = KeyCode.E;

    private GameObject grabbedObject = null;
    private Vector3 objectOffset = Vector3.zero;

    public movementPilar movementScript;
    public Transform grabPoint;
    public LayerMask movable;
    
    void Update()
    {
        
        if (Input.GetKeyDown(grabButton))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxGrabDistance,movable))
            {
                
                grabbedObject = hit.collider.gameObject;

                //grabbedObject.transform.position = grabPoint.position;

            }
        }

        if (Input.GetKeyUp(grabButton) && grabbedObject != null)
        {
            grabbedObject = null;
        }

        if (grabbedObject != null /*&& grabbedObject.tag=="Movable object"*/)
        {
            movementScript.speed = (int)2.5;
            grabbedObject.transform.position = grabPoint.position;
            //grabbedObject.transform.position = transform.position + objectOffset;
            //grabbedObject.transform.position = transform.position + new Vector3(0, 1f, 2);
        }
        else
        {
            movementScript.speed = (int)5;
        }
    }
}
