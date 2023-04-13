using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundKill : MonoBehaviour
{
    PlayerController playerController;
    BomberManger bomberManger;
    public void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        //bomberInput = FindObjectOfType<BomberInput>(); private void Awake()
        
        bomberManger = FindObjectOfType<BomberManger>();
        
    }
    private void OnTriggerExit(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            playerController.transform.position = new Vector3(0, 40, 0);
            bomberManger.playerCountBomber--;
            bomberManger.bomberPoints += 1;
            Debug.Log(bomberManger.playerCountBomber);
            bomberManger.PlayerCounter();
        }
        

    }
}
