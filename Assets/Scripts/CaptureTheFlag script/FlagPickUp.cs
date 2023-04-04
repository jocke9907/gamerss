using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagPickUp : MonoBehaviour
{
    private PlayerController playerController;
    //public Transform pickUpPosition;

     Vector3? lastPos = null;
     GameObject spawnPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = other.GetComponent<PlayerController>();
            playerController.PickUpItem(gameObject);
            lastPos = transform.position;
            
            spawnPos = Instantiate(new GameObject("spawnPos"), transform.position, Quaternion.identity);
           
            
        }
    }
    

    //public void RespawnFlag()
    //{
    //    if (lastPos != null)
    //    {
    //        GameObject newFlag = Instantiate(Resources.Load<GameObject>("Flag"), (Vector3)lastPos, transform.rotation);
    //        newFlag.tag = "Flag";
    //        lastPos = null;
    //    }
    //}

}
