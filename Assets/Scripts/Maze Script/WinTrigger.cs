using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WinTrigger : MonoBehaviour
{
    public float timer = 62f;
    public string loadScene;

    public bool isFinnished = false;

    public static int points;

    //int numOfPlayers = FindObjectsOfType<PlayerController>().Length; // Count the number of players in the scene

    List<GameObject> playersEnteredTrigger = new List<GameObject>();
    List<GameObject> playersDidNotEnterTrigger = new List<GameObject>();

    Dictionary<GameObject, int> playerPoints = new Dictionary<GameObject, int>();

    PlayerController playerController;

    AudioSource audio;
    public ScoreText scoreText;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
        playerController = GameObject.FindObjectOfType<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("Could not find PlayerScore component.");
        }

        // Initialize playersDidNotEnterTrigger to contain all players at the start
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            playersDidNotEnterTrigger.Add(player);
        }

    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            // Give 1 point to each player who has not entered the trigger
            foreach (GameObject player in playersDidNotEnterTrigger)
            {
                PlayerController playerController = player.GetComponent<PlayerController>();
                playerController.AddPoints(1);
            }

            //  Give additional points to players who have entered the trigger, based on the order they entered
            int pointsToAdd = playersEnteredTrigger.Count;
            foreach (GameObject player in playersEnteredTrigger)
            {
                PlayerController playerController = player.GetComponent<PlayerController>();
                playerController.AddPoints(pointsToAdd);
                pointsToAdd--;
            }


            Loader.TheMazePlaying = false;
            SceneManager.LoadScene(7);
        }

        int numOfPlayersLeft = playersDidNotEnterTrigger.Count;
        if (numOfPlayersLeft == 1) // Check if only one player is left
        {
            // Give 1 point to the player who has not entered the trigger
            foreach (GameObject player in playersDidNotEnterTrigger)
            {
                PlayerController playerController = player.GetComponent<PlayerController>();
                playerController.AddPoints(1);
            }

            Loader.TheMazePlaying = false;
            SceneManager.LoadScene(7);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !playerPoints.ContainsKey(other.gameObject))
        {
            audio.Play();
            int pointsToAdd = CalculatePoints();
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.AddPoints(pointsToAdd);
            playerPoints.Add(other.gameObject, pointsToAdd);

            // Add the player to the list if it's not already there
            if (!playersEnteredTrigger.Contains(other.gameObject))
            {
                playersEnteredTrigger.Add(other.gameObject);
            }

            // Remove the player from the list of players who have not entered the trigger
            if (playersDidNotEnterTrigger.Contains(other.gameObject))
            {
                playersDidNotEnterTrigger.Remove(other.gameObject);
            }

            // Add the player to the list of players who have not entered the trigger
            if (!playersEnteredTrigger.Contains(other.gameObject) && !playersDidNotEnterTrigger.Contains(other.gameObject))
            {
                playersDidNotEnterTrigger.Add(other.gameObject);
            }

            int numOfPlayers = FindObjectsOfType<PlayerController>().Length;
            if (playersEnteredTrigger.Count == numOfPlayers)  // Check if all players have entered the trigger
            {
                Loader.TheMazePlaying = false;
                SceneManager.LoadScene(7);
            }

        }
    }

    private int CalculatePoints()
    {
        int points = 0;

        int playersEntered = playerPoints.Count;

        if (playersEntered == 0)
        {
            points += 4;
        }
        else if (playersEntered == 1)
        {
            points += 3;
        }
        else if (playersEntered == 2)
        {
            points += 2;
        }
        else if (playersEntered == 3)
        {
            points += 1;
        }

        return points;
    }

}



