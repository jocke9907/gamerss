using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class FlagInGameScore : MonoBehaviour
{
    public Flag flag;
    public TextMeshProUGUI flagsCountText;
    private List<PlayerController> players = new List<PlayerController>();

    private void Start()
    {
        UpdateScoreText();
        
    }

    private void Update()
    {
        if (flag.flagsCount.Count != flagsCountText.text.Length)
        {
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        Debug.Log("Updating score text");
        players.Clear();
        players.AddRange(FindObjectsOfType<PlayerController>());

        StringBuilder scoreText = new StringBuilder();

        for (int i = 0; i < players.Count; i++)
        {
            PlayerController player = players[i];
            string playerName = GetPlayerColor(i);
            int score = flag.flagsCount.ContainsKey(player) ? flag.flagsCount[player] : 0;
            scoreText.AppendLine(playerName + ": " + score);
        }

        flagsCountText.text = scoreText.ToString();
    }

    private string GetPlayerColor(int index)
    {
        string[] colors = { "Blue", "Green", "Yellow", "Red" };
        if (index < colors.Length)
        {
            return colors[index];
        }
        else
        {
            return "Unknown";
        }
    }
}

