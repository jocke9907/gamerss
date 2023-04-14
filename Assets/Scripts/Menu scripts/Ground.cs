using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    PlayerController playerController;
    public void Awake()
    {

        playerController = FindObjectOfType<PlayerController>();
        //bomberInput = FindObjectOfType<BomberInput>(); private void Awake()

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(0, 40, 0);

        }


    }
}
