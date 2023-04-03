using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawnPoint : MonoBehaviour
{
    public static Vector3 mazeSpawnPoint;
    bool hasSpawned = false;
    int waitForFrames = 3;
    int frameCounter;
    private void Awake()
    {
        mazeSpawnPoint = transform.position;

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
                player.gameObject.transform.position = mazeSpawnPoint;
            }
            hasSpawned = true;
        }
    }
}
