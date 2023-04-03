using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnPoint : MonoBehaviour
{
    public static Vector3 platformSpawnPoint;
    bool hasSpawned = false;
    int waitForFrames = 3;
    int frameCounter;
    private void Awake()
    {
        platformSpawnPoint = transform.position;

    }
    private void Start()
    {

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
                player.gameObject.transform.position = platformSpawnPoint;
            }
            hasSpawned = true;
        }
    }
}

