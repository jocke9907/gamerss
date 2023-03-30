using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
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
    public float maxGrabDistance = 1f;
    public KeyCode grabButton = KeyCode.Tab;

    private GameObject grabbedObject = null;
    private Vector3 objectOffset = Vector3.zero;

    public movementPilar movementScript;
    public Transform grabPoint;
    public LayerMask movable;
    BoxCollider bc;
    Rigidbody rb;
    float test;



    private void Start()
    {
       
    }
    void Update()
    {
        
        if (Input.GetKeyDown(grabButton))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxGrabDistance,movable))
            {
                
                grabbedObject = hit.collider.gameObject;
                
                bc=grabbedObject.GetComponent<BoxCollider>();
                rb = grabbedObject.GetComponent<Rigidbody>();
                
            }
        }

        if (Input.GetKeyUp(grabButton) && grabbedObject != null)
        {
            grabbedObject = null;
        }

        if (grabbedObject != null)
        {
            bc.isTrigger = true;
            //rb.useGravity = false;
            //movementScript.speed = (int)2.5;
            grabbedObject.transform.position = grabPoint.position;
            
        }
        else
        {
            bc.isTrigger = false;
            //rb.useGravity = true;
            movementScript.speed = (int)5;
        }

        
    }
}
