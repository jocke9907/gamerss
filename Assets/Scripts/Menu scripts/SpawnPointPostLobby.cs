using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointPostLobby : MonoBehaviour
{
    public static Vector3 spawn;
    bool hasSpawned = false;
    int waitForFrames = 3;
    int frameCounter;

    PlayerController playerController;
    BomberManger bomberManger;
   
    Vector3 spawn1 = new Vector3(2.5f, 12, -2.5f);
    Vector3 spawn2 = new Vector3(-2.5f, 12, 2.5f);
    Vector3 spawn3 = new Vector3(2.5f, 12, 2.5f);
    Vector3 spawn4 = new Vector3(-2.5f, 12, -2.5f);

    private void Awake()
    {
        spawn = transform.position;
        playerController = FindObjectOfType<PlayerController>();
        bomberManger = FindObjectOfType<BomberManger>();

    }
    //private void Start()
    //{
    //    bomberManger.GameStart();
    //}
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

            //int[] array1 = new int[5];

            if (bomberManger.nrOfPlayers == 2)
            {
                foreach (PlayerController player in players)
                {
                    Debug.Log("spawnPlay3");
                    players[0].gameObject.transform.position = spawn1;
                    players[1].gameObject.transform.position = spawn2;
                    players[2].gameObject.transform.position = spawn3;
                    //players[1].gameObject.transform.position = spawn4;
                }
            }
            else if (bomberManger.nrOfPlayers == 3)
            {
                foreach (PlayerController player in players)
                {
                    Debug.Log("spawnPlay4");
                    players[0].gameObject.transform.position = spawn1;
                    players[1].gameObject.transform.position = spawn2;
                    players[2].gameObject.transform.position = spawn3;
                    players[3].gameObject.transform.position = spawn4;
                }
            }
            else if (bomberManger.nrOfPlayers == 1)
            {
                foreach (PlayerController player in players)
                {
                    Debug.Log("spawnPlay2");
                    players[0].gameObject.transform.position = spawn1;
                    players[1].gameObject.transform.position = spawn2;
                    //players[1].gameObject.transform.position = spawn3;
                    //players[1].gameObject.transform.position = spawn4;
                }
            }
            else if (bomberManger.nrOfPlayers == 0)
            {
                foreach (PlayerController player in players)
                {
                    Debug.Log("spawnPlay2");
                    players[0].gameObject.transform.position = spawn1;
                    //players[1].gameObject.transform.position = spawn2;
                    //players[1].gameObject.transform.position = spawn3;
                    //players[1].gameObject.transform.position = spawn4;
                }
            }




            hasSpawned = true;
        }
    }
}