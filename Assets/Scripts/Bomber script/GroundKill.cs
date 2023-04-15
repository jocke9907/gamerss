using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundKill : MonoBehaviour
{
    PlayerController playerController;
    BomberManger bomberManger;
    public void Awake()
    {
        bomberManger = FindObjectOfType<BomberManger>();
        playerController = FindObjectOfType<PlayerController>();
        //bomberInput = FindObjectOfType<BomberInput>(); private void Awake()
        
       
        
    }
    private void OnTriggerExit(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            Debug.Log("fell on ground");
            other.transform.position = new Vector3(0, 60, 0);
            //bomberManger.playerCountBomber--;
            //bomberManger.bomberPoints += 1;
            //Debug.Log(bomberManger.playerCountBomber);
            //bomberManger.PlayerCounter();

            bomberManger.redusePlayers = true;
            bomberManger.bomberPoints += 1;

            bomberManger.PlayerCounter();
        }
        

    }
}
