using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DisableJump : MonoBehaviour
{

    public GameObject[] players;

    GameObject player1;
    GameObject player2;
    GameObject player3;
    GameObject player4;

    void Awake()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");

        players[0] = player1;
        players[1] = player2;
        players[2] = player3;
        players[3] = player4;

        DisablePlayerJumping();
    }

    private void DisablePlayerJumping()
    {
        foreach (GameObject player in players)
        {
            if (!player)
            {
                continue; //går till nästa objekt i foreach loopen.
            }
            else
            {
                player.GetComponent<PlayerController>().jumpingAllowed = false;
            }
            
        }
    }
    // Update is called once per frame
    
}
