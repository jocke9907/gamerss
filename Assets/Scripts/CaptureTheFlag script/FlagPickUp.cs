using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagPickUp : MonoBehaviour
{ 
   PlayerController playerController;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            this.playerController= other.GetComponent<PlayerController>();
             playerController.PickUpItem(gameObject);
           
        }
    }
    public void Use()
    {
        if(playerController!=null)
        {
            playerController.PickUpItem(gameObject);
        }
    }
    
}
