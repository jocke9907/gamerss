using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagDrop : MonoBehaviour
{
    PlayerController playerController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
        }
    }

}
