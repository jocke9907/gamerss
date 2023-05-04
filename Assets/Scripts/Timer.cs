using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer = 10f;
    Flag flag;
    public GameObject[] playerObjects;

    private void Start()
    {
        flag = GameObject.FindObjectOfType<Flag>();
        playerObjects = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        PlayerController[] players = new PlayerController[playerObjects.Length];


        for (int i = 0; i < playerObjects.Length; i++)
        {
            players[i] = playerObjects[i].GetComponent<PlayerController>();
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GameObject[] flags = GameObject.FindGameObjectsWithTag("Flag");
            flag.AssignPoints();
            foreach (var player in players)
            {
                int pointsToAdd = player.GetComponent<PlayerController>().FlagScore;
                player.GetComponent<PlayerController>().AddPoints(pointsToAdd);
                foreach(GameObject flag in flags)
                {
                    Destroy(flag);
                }
            }
           

            
            Loader.captureTheFlagPlaying = false;
            SceneManager.LoadScene(7);


        }
    }
}
