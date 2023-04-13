using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

    BomberManger bomberManger;

    private void Awake()
    {
        bomberManger = FindObjectOfType<BomberManger>();
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController;
        MarkerInteract markerInteract;
        BomberInput input;
        
        if (other.CompareTag("Player"))
        {
            playerController = other.GetComponent<PlayerController>();
            //playerController.PickUpItem(gameObject);
            bomberManger.bombUppgrade += 1;
            Debug.Log("found item");
            
        }
        Destroy(gameObject);
    }
}
