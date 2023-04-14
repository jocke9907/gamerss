using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController;
        MarkerInteract markerInteract;
        BomberInput input;
        if (other.CompareTag("Player"))
        {
            playerController = other.GetComponent<PlayerController>();
            //playerController.PickUpItem(gameObject);
            BomberManger.bombUppgrade += 1;
            Debug.Log("found item");
            
        }
        Destroy(gameObject);
    }
}
