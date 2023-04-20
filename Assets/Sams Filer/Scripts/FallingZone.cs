using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingZone : MonoBehaviour
{
    public float randX;
    public float randZ;

    List<GameObject> listObject = new List<GameObject>();

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Movable object"))
        {
            randX = Random.Range(-10, 10);
            randZ= Random.Range(-10, 5);
            other.transform.position = new Vector3(randX, 30, randZ);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            randX = Random.Range(-10, 10);
            randZ = Random.Range(-10, 5);
            other.gameObject.transform.position = new Vector3(randX, 10, randZ);
        }
    }
}
