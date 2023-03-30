using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagDropPoint : MonoBehaviour
{
    PlayerController playerController;
    
    private void OnTriggerEnter(Collider other)
    {
        //playerController.HasFlag();
        if (other.tag == "player")
        {

        }
    }

}
