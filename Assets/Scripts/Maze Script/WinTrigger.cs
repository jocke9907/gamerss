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

    List<GameObject> playersEnteredTrigger = new List<GameObject>();

    Dictionary<GameObject, int> playerPoints = new Dictionary<GameObject, int>();
    PlayerScore playerScore;

    private void Start()
    {
        playerScore = GameObject.FindObjectOfType<PlayerScore>();
        if (playerScore == null)
        {
            Debug.LogError("Could not find PlayerScore component.");
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (/*playersEnteredTrigger.Count == numOfPlayers ||*/ timer <= 0)
        {
            Loader.TheMazePlaying = false;
            SceneManager.LoadScene(7);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !playerPoints.ContainsKey(other.gameObject))
        {
            int pointsToAdd = CalculatePoints();
            PlayerScore playerScore = other.gameObject.GetComponent<PlayerScore>();
            playerScore.AddPoints(pointsToAdd);
            playerPoints.Add(other.gameObject, pointsToAdd);


            // Add the player to the list if it's not already there
            if (!playersEnteredTrigger.Contains(other.gameObject))
            {
                playersEnteredTrigger.Add(other.gameObject);
            }

            // Count the number of players in the scene
            int numOfPlayers = FindObjectsOfType<PlayerController>().Length;

            // Check if all players have entered the trigger
            if (playersEnteredTrigger.Count == numOfPlayers)
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



