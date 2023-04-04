using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagDropPoint : MonoBehaviour
{
    public Transform spawnPos;
    FlagPickUp flag;
    
 
    private void OnTriggerEnter(Collider other)
    {
        
        PlayerController player=other.GetComponent<PlayerController>();
        if(other.tag=="Player"&&player.heldItem!=null)
        {
            Destroy(player.heldItem);
            player.heldItem=null;
            Invoke("RespawnFlag", 5F);
        }

    }
    private void RespawnFlag()
    {
        GameObject newFlag = Instantiate(Resources.Load<GameObject>("Flag"), spawnPos.position, spawnPos.rotation);
        newFlag.tag = "Flag";
    }

}