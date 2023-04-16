using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scoreSystem : MonoBehaviour
{
    public GameObject[] players;
    public TMP_Text scoreText;
    //public TextMeshPro scoreText;
    int placement = 0;

    private List<GameObject> finishOrder = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<movementPilar>().finished==false)
        {
            other.GetComponent<movementPilar>().finished = true;
            
            finishOrder.Add(other.gameObject);
            

            if (placement == 0)
            {
                finishOrder[placement].GetComponent<movementPilar>().AddScore(4);
            }
            else if(placement == 1)
            {
                finishOrder[placement].GetComponent<movementPilar>().AddScore(3);
            }
            else if (placement == 2)
            {
                finishOrder[placement].GetComponent<movementPilar>().AddScore(2);
            }
            else if (placement == 3)
            {
                finishOrder[placement].GetComponent<movementPilar>().AddScore(1);
            }
            placement++;




            //for (int i = 0; i < finishOrder.Count; i++)
            //{
            //    if (i == 0)
            //    {
            //        finishOrder[i].GetComponent<movementPilar>().AddScore(4);
            //    }
            //    else if (i == 1)
            //    {
            //        finishOrder[i].GetComponent<movementPilar>().AddScore(3);
            //    }
            //    else if (i == 2)
            //    {
            //        finishOrder[i].GetComponent<movementPilar>().AddScore(2);
            //    }
            //    else
            //    {
            //        finishOrder[i].GetComponent<movementPilar>().AddScore(1);
            //    }
            //}

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
            scoreText.text += "Player " + (i + 1) + ": " + players[i].GetComponent<movementPilar>().totalScore + "\n";
        }
    }
}
