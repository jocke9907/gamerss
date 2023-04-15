using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scoreSystem : MonoBehaviour
{
    public GameObject[] players;
    public TextMeshPro scoreText;

    private List<GameObject> finishOrder = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Add the player to the list of finishers
            finishOrder.Add(other.gameObject);

            // Sort the finishers by their distance from the trigger
            finishOrder.Sort((a, b) => Vector3.Distance(a.transform.position, transform.position).CompareTo(Vector3.Distance(b.transform.position, transform.position)));

            // Calculate and display the scores
            for (int i = 0; i < finishOrder.Count; i++)
            {
                if (i == 0)
                {
                    finishOrder[i].GetComponent<PlayerController>().AddScore(4);
                }
                else if (i == 1)
                {
                    finishOrder[i].GetComponent<PlayerController>().AddScore(3);
                }
                else if (i == 2)
                {
                    finishOrder[i].GetComponent<PlayerController>().AddScore(2);
                }
                else
                {
                    finishOrder[i].GetComponent<PlayerController>().AddScore(1);
                }
            }

            // Update the score display
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        // Clear the old scores
        scoreText.text = "";

        // Display the new scores
        for (int i = 0; i < players.Length; i++)
        {
            scoreText.text += "Player " + (i + 1) + ": " + players[i].GetComponent<PlayerController>().totalScore + "\n";
        }
    }
}
