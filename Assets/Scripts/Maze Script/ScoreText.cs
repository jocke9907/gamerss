using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    // Reference to the player controller script for each player
    public List<PlayerController> players;

    // Reference to the text component to display the scores
    public Text scoreText;

    // Update the score text with the current scores
    void LateUpdate()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText == null)
        {
            Debug.LogError("ScoreText component not assigned.");
            return;
        }

        string text = "";
        for (int i = 0; i < players.Count; i++)
        {
            int score = players[i].GetScore();
            text += string.Format("Player {0}: {1}\n", i + 1, score);
        }
        scoreText.text = text;
    }
}


