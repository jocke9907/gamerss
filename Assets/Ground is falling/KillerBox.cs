using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerBox : MonoBehaviour
{
    static public int points = 0;
    [SerializeField] int playercounter = 0;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            points = points + 1;
            playercounter++;
        }
        if(playercounter >=4)
        {
            Loader.Load(Loader.Scene.Lobby);
        }
    }

}