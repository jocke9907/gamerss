using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    PlayerController playerController;
    public void Awake()
    {

        playerController = FindObjectOfType<PlayerController>();
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(-14, -13, -5);
           

        }


    }
}
