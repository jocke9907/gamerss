using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWallbreaker : MonoBehaviour
{

    public GameObject[] players;


    GameObject player1;
    GameObject player2;
    GameObject player3;
    GameObject player4;


    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");

        players[0] = player1;
        players[1] = player2;
        players[2] = player3;
        players[3] = player4;

        Loader.TheMazePlaying = false;
        Loader.PlatformGamePlaying = false;
        Loader.wallClimberPlaying = false;
        Loader.bomberGamePlaying = false;
        Loader.captureTheFlagPlaying = false;
        Loader.spinningWheelPlaying = false;
        Loader.LavaGroundPlaying = false;



        foreach (GameObject player in players)
        {
            if (!player)
            {
                continue; //går till nästa objekt i foreach loopen.
            }
            if (player.CompareTag("Player"))
            {
                player.GetComponent<PlayerController>().finished = false;
                player.GetComponent<PlayerController>().tempScore = 0;
                player.GetComponent<PlayerController>().jumpingAllowed = true;


            }
        }
    }

}
