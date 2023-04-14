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
        Debug.Log("Maze spawn point set to " + mazeSpawnPoint);

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
            Debug.Log("Found " + players.Length + " player objects in scene.");
            foreach (PlayerController player in players)
            {
                player.gameObject.transform.position = mazeSpawnPoint;
                Debug.Log("Set player object position to " + mazeSpawnPoint);
            }
            hasSpawned = true;
        }
    }
}
