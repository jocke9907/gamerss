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
        StartCoroutine(SetPlayerPosition());
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


    private IEnumerator SetPlayerPosition()
    {
        yield return new WaitForEndOfFrame();
        PlayerController[] players = FindObjectsOfType<PlayerController>();
        if (players.Length == 0)
        {
            Debug.Log("No player objects found in scene. Make sure the player object is present and has a PlayerController component attached.");
        }
        else
        {
            foreach (PlayerController player in players)
            {
                player.gameObject.transform.position = mazeSpawnPoint;
                Debug.Log("Set player object position to " + mazeSpawnPoint);
            }
        }
    }
}
