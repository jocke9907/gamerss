using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbySpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector3 lobbySpawnPoint;
    bool hasSpawned = false;
    int waitForFrames = 3;
    int frameCounter;
    private void Awake()
    {
        lobbySpawnPoint = transform.position;

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
                player.gameObject.transform.position = lobbySpawnPoint;
            }
            hasSpawned = true;
        }
    }
}
