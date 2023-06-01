using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundKill : MonoBehaviour
{
    // not usesd 
    PlayerController playerController;
    BomberManger bomberManger;
    bool groundKill;
    public void Awake()
    {
        bomberManger = FindObjectOfType<BomberManger>();
        playerController = FindObjectOfType<PlayerController>();
        //bomberInput = FindObjectOfType<BomberInput>(); private void Awake()
        
       
        
    }
    private void OnTriggerEnter(Collider other)
    {
        


        // this scripts is bugged
        if (other.CompareTag("Player") )
        {
            other.transform.TryGetComponent(out PlayerController playerController);

            if (playerController.veryDead == false )
            {
                bomberManger.bomberPoints -= 1;
                playerController.totalScore -= bomberManger.bomberPoints;
                bomberManger.redusePlayers = true;
                playerController.veryDead = true;
               
               
            }
            

          
                Debug.Log("fell on ground");
            

            bomberManger.PlayerCounter();
        }
        

    }
}
