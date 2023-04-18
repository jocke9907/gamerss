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
    Vector3 spawn2 = new Vector3(17, 2, 18);
    Vector3 spawn3 = new Vector3(17, 2, 1);
    Vector3 spawn4 = new Vector3(1, 2, 1);

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

            if (bomberManger.playerCountBomber == 2)
            {
                foreach (PlayerController player in players)
                {
                    Debug.Log("mazespawn");
                    players[0].gameObject.transform.position = spawn1;
                    players[1].gameObject.transform.position = spawn2;
                    players[2].gameObject.transform.position = spawn3;
                    //players[1].gameObject.transform.position = spawn4;
                }
            }
            else if (bomberManger.playerCountBomber == 3)
            {
                foreach (PlayerController player in players)
                {
                    Debug.Log("mazespawn");
                    players[0].gameObject.transform.position = spawn1;
                    players[1].gameObject.transform.position = spawn2;
                    players[2].gameObject.transform.position = spawn3;
                    players[3].gameObject.transform.position = spawn4;
                }
            }
            else if (bomberManger.playerCountBomber == 1)
            {
                foreach (PlayerController player in players)
                {
                    Debug.Log("mazespawn");
                    players[0].gameObject.transform.position = spawn1;
                    players[1].gameObject.transform.position = spawn2;
                    //players[1].gameObject.transform.position = spawn3;
                    //players[1].gameObject.transform.position = spawn4;
                }
            }




            hasSpawned = true;
        }
    }
    //public static Vector3 mazeSpawnPoint;
    //bool hasSpawned = false;
    //int waitForFrames = 3;
    //int frameCounter;
    //private void Awake()
    //{
    //    mazeSpawnPoint = transform.position;
    //    Debug.Log("Maze spawn point set to " + mazeSpawnPoint);

    //}
    //private void Start()
    //{

    //}
    //private void Update()
    //{
    //    if (hasSpawned)
    //    {
    //        return;
    //    }
    //    frameCounter++;
    //    if (frameCounter >= waitForFrames)
    //    {
    //        PlayerController[] players = FindObjectsOfType<PlayerController>();
    //        Debug.Log("Found " + players.Length + " player objects in scene.");
    //        foreach (PlayerController player in players)
    //        {
    //            player.gameObject.transform.position = mazeSpawnPoint;
    //            Debug.Log("Set player object position to " + mazeSpawnPoint);
    //        }
    //        hasSpawned = true;
    //    }
    //}
}
