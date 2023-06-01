using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawnPoint : MonoBehaviour
{
    public static Vector3 spawn;
    bool hasSpawned = false;
    int waitForFrames = 3;
    int frameCounter;

    PlayerController playerController;
    BomberManger bomberManger;
    Vector3 spawn1 = new Vector3(1, 2, 18);
    Vector3 spawn2 = new Vector3(17, 2, 1);
    Vector3 spawn3 = new Vector3(17, 2, 18);
    Vector3 spawn4 = new Vector3(1, 2, 1);

    private void Awake()
    {
        spawn = transform.position;
        playerController = FindObjectOfType<PlayerController>();
        bomberManger = FindObjectOfType<BomberManger>();

    }

    private void FixedUpdate()
    {

        if (hasSpawned)
        {
            return;
        }

        frameCounter++;
        if (frameCounter >= waitForFrames)
        {
            PlayerController[] players = FindObjectsOfType<PlayerController>();
            playerController = FindObjectOfType<PlayerController>();

            if (bomberManger.nrOfPlayers == 2)
            {
                foreach (PlayerController player in players) // if there is  3 players 
                {
                    Debug.Log("mazespawn");
                    players[0].gameObject.transform.position = spawn1;
                    players[1].gameObject.transform.position = spawn2;
                    players[2].gameObject.transform.position = spawn3;
                }
            }
            else if (bomberManger.nrOfPlayers == 3)
            {
                foreach (PlayerController player in players) // 4 players
                {
                    Debug.Log("mazespawn");
                    players[0].gameObject.transform.position = spawn1;
                    players[1].gameObject.transform.position = spawn2;
                    players[2].gameObject.transform.position = spawn3;
                    players[3].gameObject.transform.position = spawn4;
                }
            }
            else if (bomberManger.nrOfPlayers == 1) // 2 players
            {
                foreach (PlayerController player in players)
                {
                    Debug.Log("mazespawn");
                    players[0].gameObject.transform.position = spawn1;
                    players[1].gameObject.transform.position = spawn2;
                  
                }
            }

            hasSpawned = true;
        }
    }
  
}
