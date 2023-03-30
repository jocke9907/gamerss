using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class FlagDropPoint : MonoBehaviour
{
    
    [SerializeField] public GameObject flag;
    [SerializeField] public Vector3 spawnPosition;
    PlayerController playerController;
    
    private void OnTriggerEnter(Collider other)
    {
        //playerController.HasFlag();
        if (other.tag == "Player")
        {
            if(flag!=null&&playerController!=null&&playerController.HasFlag(flag))
            {
                flag.transform.position = spawnPosition;
                playerController.DropItem(flag);
                playerController.DropFlag();
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerController=other.GetComponent<PlayerController>();
        }
    }

}
