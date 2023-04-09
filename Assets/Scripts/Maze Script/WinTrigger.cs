using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WinTrigger : MonoBehaviour
{
    public float timer = 63f;
    public string loadScene;
    public static int points = 0;

    public bool isFinnished = false;

    public int numOfPlayers = 4;
    int playerEnteredTrigger = 0;

    PlayerScore playerScore;

    Dictionary<GameObject, int> playerScores = new Dictionary<GameObject, int>();

    void Start()
    {
        playerScore = FindObjectOfType<PlayerScore>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (playerEnteredTrigger == numOfPlayers || timer <= 0)
        {
            SceneManager.LoadScene(5);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            GameObject player = other.gameObject;

            if (!playerScores.ContainsKey(player))
            {
                int scoreValue = 0;

                switch (playerScores.Count)
                {
                    case 0:
                        scoreValue += 50;
                        break;

                    case 1:
                        scoreValue += 30;
                        break;

                    case 2:
                        scoreValue += 20;
                        break;

                    case 3:
                        scoreValue += 10;
                        break;
                }

                playerScores[player] = scoreValue;
            }

            playerScore.currentScore = playerScores[player];
            playerEnteredTrigger ++;

            other.GetComponent<PlayerScore>();
            //playerScore.currentScore += 50;

        }
    }

}








//public float timer = 63f;
//public string loadScene;
//public static int[] points = { 50, 30, 20, 10 };
//// array of points for each player based on finishing position
//// the first player to reach the center gets points[0] points,
//// the second player gets points[1] points, and so on.

//private List<GameObject> players = new List<GameObject>();
//// a list of all players in the game

//private int playersReachedGoal = 0;
//// number of players who have reached the goal

//private void Update()
//{
//    timer -= Time.deltaTime;
//    if (timer <= 0f)
//    {
//        // timer has run out, trigger scene change
//        SceneManager.LoadScene(loadScene);
//    }
//}

//private void OnTriggerEnter(Collider other)
//{
//    if (other.CompareTag("Player"))
//    {
//        if (!players.Contains(other.gameObject))
//        {
//            // add new player to the list of players
//            players.Add(other.gameObject);
//        }

//        if (players.Count == 1)
//        {
//            // first player to reach the center gets points[0] points
//            PlayerScore playerScore = other.GetComponent<PlayerScore>();
//            playerScore.currentScore += points[0];
//        }
//        else
//        {
//            // sort the list of players by their distance to the center
//            players.Sort((a, b) =>
//            {
//                float distanceToCenterA = Vector3.Distance(a.transform.position, transform.position);
//                float distanceToCenterB = Vector3.Distance(b.transform.position, transform.position);
//                return distanceToCenterA.CompareTo(distanceToCenterB);
//            });

//            // assign points to each player based on their position in the race
//            for (int i = 0; i < players.Count; i++)
//            {
//                PlayerScore playerScore = players[i].GetComponent<PlayerScore>();
//                playerScore.currentScore += points[i];
//            }
//        }

//        // disable player movement and mark game as finished
//        other.GetComponent<CharacterMovement>().enabled = false;
//        //isFinished = true;

//        // increment the number of players who have reached the goal
//        playersReachedGoal++;

//        // check if all players have reached the goal
//        if (playersReachedGoal == players.Count)
//        {
//            // all players have reached the goal, trigger scene change
//            SceneManager.LoadScene(5);
//        }
//    }
//}




