using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpinningWheel : MonoBehaviour
{
    //-------------------------WRITTEN BY SAM--------------------------

    // This scripts makes sure that players 1-4 start on specific positions
    // every time the minigame spinning wheel starts.

    public GameObject spawnPlayer1;
    public GameObject spawnPlayer2;
    public GameObject spawnPlayer3;
    public GameObject spawnPlayer4;

    Vector3 player1Pos;
    Vector3 player2Pos;
    Vector3 player3Pos;
    Vector3 player4Pos;

    bool hasSpawned = false;




    private void Start()
    {
        player1Pos = spawnPlayer1.transform.position;
        player2Pos = spawnPlayer2.transform.position;
        player3Pos = spawnPlayer3.transform.position;
        player4Pos = spawnPlayer4.transform.position;


    }

    private void FixedUpdate()
    {
        if (hasSpawned == false)
        {
            PlayerController[] players = FindObjectsOfType<PlayerController>();
            foreach (PlayerController player in players)
            {
                if (player.gameObject.name == "Player1")
                {
                    player.gameObject.transform.position = player1Pos;
                }
                else if (player.gameObject.name == "Player2")
                {
                    player.gameObject.transform.position = player2Pos;
                }
                else if (player.gameObject.name == "Player3")
                {
                    player.gameObject.transform.position = player3Pos;
                }
                else if (player.gameObject.name == "Player4")
                {
                    player.gameObject.transform.position = player4Pos;
                }


            }
            hasSpawned = true;
        }

    }
}
