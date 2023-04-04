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
            points++;
            playercounter--;
            //other.gameObject.transform.position = new Vector3(0,3,0);
            //other.gameObject.SetActive(false);
        }
        if(playercounter <= 0)
        {
            Loader.PlatformGamePlaying = false;
            Loader.Load(Loader.Scene.Lobby);
            
        }
        
    }

}