using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureSpawnPoint : MonoBehaviour
{
    public static Vector3 spawn;
    bool hasSpawned = false;
    int waitForFrames = 3;
    int frameCounter;

    PlayerController playerController;
    BomberManger bomberManger;
    [SerializeField] GameObject spawn1;
    [SerializeField] GameObject spawn2;
    [SerializeField] GameObject spawn3;
    [SerializeField] GameObject spawn4;

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
                    players[0].gameObject.transform.position = spawn1.transform.position;
                    players[1].gameObject.transform.position = spawn2.transform.position;
                    players[2].gameObject.transform.position = spawn3.transform.position;
                    //players[1].gameObject.transform.position = spawn4;
                }
            }
            else if (bomberManger.nrOfPlayers == 3)
            {
                foreach (PlayerController player in players)
                {
                    Debug.Log("spawnPlay4");
                    players[0].gameObject.transform.position = spawn1.transform.position;
                    players[1].gameObject.transform.position = spawn2.transform.position;
                    players[2].gameObject.transform.position = spawn3.transform.position;
                    players[3].gameObject.transform.position = spawn4.transform.position;
                }
            }
            else if (bomberManger.nrOfPlayers == 1)
            {
                foreach (PlayerController player in players)
                {
                    Debug.Log("spawnPlay2");
                    players[0].gameObject.transform.position = spawn1.transform.position;
                    players[1].gameObject.transform.position = spawn2.transform.position;
                    //players[1].gameObject.transform.position = spawn3;
                    //players[1].gameObject.transform.position = spawn4;
                }
            }
            else if (bomberManger.nrOfPlayers == 0)
            {
                foreach (PlayerController player in players)
                {
                    Debug.Log("spawnPlay2");
                    players[0].gameObject.transform.position = spawn1.transform.position;
                    //players[1].gameObject.transform.position = spawn2;
                    //players[1].gameObject.transform.position = spawn3;
                    //players[1].gameObject.transform.position = spawn4;
                }
            }




            hasSpawned = true;
        }
    }
}
