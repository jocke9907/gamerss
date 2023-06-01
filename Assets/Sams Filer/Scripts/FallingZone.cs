using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallingZone : MonoBehaviour
{
    //----------SCRIPT WRITTEN BY SAM----------------------

    // this script is used for teleporting the movable objects that fall outside of the map back into the map.
    // They spawn randomly back into a certain area within the map, upon touching the trigger underneat the map.
    // It is only used in wallclimber.


    public float randX;
    public float randZ;

    List<GameObject> listObject = new List<GameObject>();
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Movable object"))
        {
            randX = Random.Range(-10, 10);
            randZ = Random.Range(-10, 5);
            other.transform.position = new Vector3(randX, 30, randZ);
        }
        
    }

}
