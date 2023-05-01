using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundKill : MonoBehaviour
{
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
        



        if (other.CompareTag("Player") )
        {
            other.transform.TryGetComponent(out PlayerController playerController);

            if (playerController.veryDead == false )
            {
                bomberManger.bomberPoints -= 1;
                playerController.totalScore -= bomberManger.bomberPoints;
                bomberManger.redusePlayers = true;
                playerController.veryDead = true;
                playerController.veryDead = true;
               
            }
            

            //if (other == TryGetComponent(out PlayerController playerController) )
            //{
                
            //}
                Debug.Log("fell on ground");
            
            


            //bomberManger.bomberPoints += 1;
            //if( other == playerController)
            //{
            //    playerController.totalScore -= bomberManger.bomberPoints;
            //    bomberManger.redusePlayers = true;
            //    //if (groundKill == false )
            //    //{
                    
            //    //    groundKill = true;
            //    //}
               
            //}
           


            bomberManger.PlayerCounter();
        }
        

    }
}
