using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public List<Text> scoreTexts;
    void Start()
    {
        // Get all player controllers in the scene
        PlayerController[] playerControllers = FindObjectsOfType<PlayerController>();

        // Display each player's score
        for (int i = 0; i < playerControllers.Length; i++)
        {
            Text scoreText = scoreTexts[i];
            scoreText.text = "Player " + (i + 1) + " Score: " + playerControllers[i].totalScore;
        }
    }

}
