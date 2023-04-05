using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimberInput : MonoBehaviour
{

    private PlayerController playerController;
    public Transform grabPoint;
    public LayerMask movable;
    BoxCollider bc;
    private GameObject grabbedObject = null;
    private Vector3 objectOffset = Vector3.zero;
    Rigidbody rb;
    float test;
    public void UpdateWallClimberTo()
    {
        HandelGrabbing();
    }

    public void HandelGrabbing()
    {
        float maxGrabDistance = 1f;


        if (playerController.inputE == true)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxGrabDistance, movable))
            {

                grabbedObject = hit.collider.gameObject;

                bc = grabbedObject.GetComponent<BoxCollider>();
                rb = grabbedObject.GetComponent<Rigidbody>();

            }
        }

        if (playerController.inputE == true && grabbedObject != null)
        {
            grabbedObject = null;
        }

        if (grabbedObject != null)
        {
            bc.isTrigger = true;
            //grabbedObject.transform.rotation = Quaternion.identity.x;
            //grabbedObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            Quaternion newRotation = Quaternion.Euler(0f, grabPoint.rotation.eulerAngles.y, 0f);
            grabbedObject.transform.rotation = newRotation;
            //rb.useGravity = false;
            //movementScript.speed = (int)2.5;
            grabbedObject.transform.position = grabPoint.position;

        }
        else
        {
            bc.isTrigger = false;
            //rb.useGravity = true;
            //movementScript.speed = (int)5;
        }
    }
}
