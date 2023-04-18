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
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided with"+other.name);
        if (other.CompareTag("Player"))
        {

            other.transform.position = new Vector3(0, 40, 0);
            Debug.Log(other.transform.position);
            Debug.Log("ground");
            //other.transform.position = new Vector3(0, 40, 0);
            //other.transform.position = new Vector3(0, 40, 0);

        }


    }
}
