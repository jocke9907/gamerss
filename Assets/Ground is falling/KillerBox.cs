using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerBox : MonoBehaviour
{
    static public int points = 0;
    public static int playercounter = 4;

    // Start is called before the first frame update
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            points = points + 1;
            playercounter--;
        }
        if(playercounter <= 0)
        {
            Loader.Load(Loader.Scene.Lobby);
        }
        
    }

}