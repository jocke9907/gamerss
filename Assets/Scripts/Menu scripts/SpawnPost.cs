using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPost : MonoBehaviour
{
    public static Vector3 spawnPointPost;
    bool hasSpawned = false;
    int waitForFrames = 3;
    int frameCounter;
    private void Awake()
    {
        spawnPointPost = transform.position;

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
            foreach (PlayerController player in players)
            {
                player.gameObject.transform.position = spawnPointPost;
                Debug.Log("spawn player");
            }
            hasSpawned = true;
        }
    }
}
