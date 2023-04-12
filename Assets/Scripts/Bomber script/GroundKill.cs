using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundKill : MonoBehaviour
{
    PlayerController playerController;

    public void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        //bomberInput = FindObjectOfType<BomberInput>();
    }
    private void OnTriggerExit(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            playerController.transform.position = new Vector3(0, 40, 0);
            BomberManger.playerCountBomber--;
            BomberManger.bomberPoints += 1;
            Debug.Log(BomberManger.playerCountBomber);
            BomberManger.PlayerCounter();
        }
        

    }
}
