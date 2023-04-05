using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointWallClimber : MonoBehaviour
{
    public static Vector3 wallSpawnPoint;
    bool hasSpawned = false;
    int waitForFrames = 3;
    int frameCounter;
    private void Awake()
    {
        wallSpawnPoint = transform.position;

    }
   
    private void Update()
    {
        if (hasSpawned)
        {
            return;
        }
        frameCounter++;
        if (frameCounter >= waitForFrames)
        {
            PlayerController[] players = FindObjectsOfType<PlayerController>();
            foreach (PlayerController player in players)
            {
                player.gameObject.transform.position = wallSpawnPoint;
            }
            hasSpawned = true;
        }
    }
}
