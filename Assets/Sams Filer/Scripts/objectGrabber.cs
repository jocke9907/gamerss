using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class objectGrabber : MonoBehaviour
{

  
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
            //grabbedObject.transform.rotation = Quaternion.identity.x;
            //grabbedObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            Quaternion newRotation= Quaternion.Euler(0f, grabPoint.rotation.eulerAngles.y, 0f);
            grabbedObject.transform.rotation = newRotation;
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
