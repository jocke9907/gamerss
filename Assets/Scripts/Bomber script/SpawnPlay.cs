using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlay : MonoBehaviour
{
    public static Vector3 spawn;
    bool hasSpawned = false;
    int waitForFrames = 3;
    int frameCounter;
  
    PlayerController playerController;
    Vector3 spawn1 = new Vector3(16, 12, 16);
    Vector3 spawn2 = new Vector3(16, 12, -16);
    Vector3 spawn3 = new Vector3(-16, 12, 16);
    Vector3 spawn4 = new Vector3(-16, 12, -16);

    private void Awake()
    {
        spawn = transform.position;
        playerController = FindObjectOfType<PlayerController>();

    }
    private void Start()
    {

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
            PlayerController[] players = FindObjectsOfType<PlayerController>() ;
            playerController = FindObjectOfType<PlayerController>();

            //int[] array1 = new int[5];


            foreach (PlayerController player in players)
            {
                players[0].gameObject.transform.position = spawn1;

                players[1].gameObject.transform.position = spawn2;
                players[1].gameObject.transform.position = spawn3;
                players[1].gameObject.transform.position = spawn4;


            }

            
            hasSpawned = true;
        }
    }
}
