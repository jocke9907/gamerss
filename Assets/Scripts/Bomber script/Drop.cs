using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

    // this scipts was uses for when barrels where destroy. They would then drop diffrent bosters. This is however not useed

    BomberManger bomberManger;
    PlayerController playerController;
    private void Awake()
    {
        bomberManger = FindObjectOfType<BomberManger>();
        playerController = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
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
