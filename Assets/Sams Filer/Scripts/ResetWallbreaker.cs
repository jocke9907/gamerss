using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWallbreaker : MonoBehaviour
{

    public GameObject[] players;


    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;


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

      
        foreach (GameObject player in players)
        {
            if (!player)
            {
                continue; //går till nästa objekt i foreach loopen.
            }
            if (player.CompareTag("Player"))
            {
                player.GetComponent<PlayerController>().finished = false;
                player.GetComponent<PlayerController>().wallClimberScore = 0;

            }
        }
    }

}
