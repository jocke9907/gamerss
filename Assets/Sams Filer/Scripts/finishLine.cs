using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class finishLine : MonoBehaviour
{
    // Start is called before the first frame update
    //private void OnTriggerEnter(Collider other)
    //{
    //    GameObject hitObject = other.gameObject;
    //    if (hitObject.tag == "Player")
    //    {
    //        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //        SceneManager.LoadScene("SampleScene");
    //    }
    //}
    public Text positionText;
    public Text scoreText;
    private Dictionary<string, int> positions = new Dictionary<string, int>();
    private Dictionary<string, int> scores = new Dictionary<string, int>();
    private int playersFinished = 0;
    public movementPilar player;

    void Start()
    {
        // Initialize positions and scores dictionaries with player tags
        positions.Add("Player1", 0);
        positions.Add("Player2", 0);
        positions.Add("Player3", 0);
        positions.Add("Player4", 0);
        scores.Add("Player1", 0);
        scores.Add("Player2", 0);
        scores.Add("Player3", 0);
        scores.Add("Player4", 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<movementPilar>();
            if (player.finished) return; // Player has already crossed the finish line

            player.finished = true;
            playersFinished++;

            // Determine player's position based on number of players who have finished
            if (playersFinished == 1) positions[other.tag] = 1;
            else if (playersFinished == 2) positions[other.tag] = 2;
            else if (playersFinished == 3) positions[other.tag] = 3;
            else positions[other.tag] = 4;

            // Update player's score based on finishing position
            switch (positions[other.tag])
            {
                case 1:
                    scores[other.tag] += 40;
                    break;
                case 2:
                    scores[other.tag] += 30;
                    break;
                case 3:
                    scores[other.tag] += 20;
                    break;
                case 4:
                    scores[other.tag] += 10;
                    break;
            }

            // Update position and score text on screen
            positionText.text = "1st: " + GetPlayerByPosition(1) + "\n2nd: " + GetPlayerByPosition(2) + "\n3rd: " + GetPlayerByPosition(3) + "\n4th: " + GetPlayerByPosition(4);
            scoreText.text = "Player1: " + scores["Player1"] + "\nPlayer2: " + scores["Player2"] + "\nPlayer3: " + scores["Player3"] + "\nPlayer4: " + scores["Player4"];
        }
    }

    private string GetPlayerByPosition(int position)
    {
        // Get player tag with given position
        foreach (KeyValuePair<string, int> entry in positions)
        {
            if (entry.Value == position) return entry.Key;
        }

        return "";
    }
}
