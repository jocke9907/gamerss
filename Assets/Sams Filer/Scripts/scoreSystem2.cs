using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class scoreSystem2 : MonoBehaviour
{
    public GameObject[] players;
    //public List<GameObject> players = new List<GameObject>();

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public TMP_Text scoreText;
    //public TextMeshPro scoreText;
    int placement = 0;
    bool hej = true;
    private List<GameObject> finishOrder = new List<GameObject>();
    public enum NumberPlayers {one,two,three,four}
    public NumberPlayers numberPlayers = NumberPlayers.one;

    private void Start()
    {

        player1 = GameObject.Find("Player1(Clone)");
        player2 = GameObject.Find("Player1(Clone)1");
        player3 = GameObject.Find("Player1(Clone)2");
        player4 = GameObject.Find("Player1(Clone)3");

        players[0] = player1;
        players[1] = player2;
        players[2] = player3;
        players[3] = player4;
    }
    private void OnTriggerEnter(Collider other)
    {

        switch (numberPlayers)
        {
            case NumberPlayers.one:
               
                
                if (other.CompareTag("Player") && other.GetComponent<movementPilar>().finished == false)
                {
                    other.GetComponent<movementPilar>().finished = true;

                    finishOrder.Add(other.gameObject);

                    finishOrder[placement].GetComponent<movementPilar>().AddScore(4);
                    
                    UpdateScoreText();
                }
                break;

            case NumberPlayers.two:

                if (other.CompareTag("Player") && other.GetComponent<movementPilar>().finished == false)
                {
                    other.GetComponent<movementPilar>().finished = true;
                    finishOrder.Add(other.gameObject);

                    if (placement == 0)
                    {
                        finishOrder[placement].GetComponent<movementPilar>().AddScore(4);
                    }                 
                    placement++;
                    UpdateScoreText();
                }

                if (placement == 1)
                {
                    foreach (GameObject player in players)
                    {
                        if (player.GetComponent<movementPilar>().finished == false)
                        {
                            player.GetComponent<movementPilar>().finished = true;
                            player.GetComponent<movementPilar>().AddScore(3);
                           
                        }
                    }
                    UpdateScoreText();
                }
                break;

            case NumberPlayers.three:

                if (other.CompareTag("Player") && other.GetComponent<movementPilar>().finished == false)
                {
                    other.GetComponent<movementPilar>().finished = true;

                    finishOrder.Add(other.gameObject);


                    if (placement == 0)
                    {
                        finishOrder[placement].GetComponent<movementPilar>().AddScore(4);
                    }
                    else if (placement == 1)
                    {
                        finishOrder[placement].GetComponent<movementPilar>().AddScore(3);
                    } 
                    placement++;
                    UpdateScoreText();
                }
                if (placement == 2)
                {
                    foreach (GameObject player in players)
                    {
                        if (player.GetComponent<movementPilar>().finished == false)
                        {
                            player.GetComponent<movementPilar>().finished = true;
                            player.GetComponent<movementPilar>().AddScore(2);
                        }
                    }
                    UpdateScoreText();
                }
                break;

            case NumberPlayers.four:

                if (other.CompareTag("Player") && other.GetComponent<movementPilar>().finished == false)
                {
                    other.GetComponent<movementPilar>().finished = true;

                    finishOrder.Add(other.gameObject);


                    if (placement == 0)
                    {
                        finishOrder[placement].GetComponent<movementPilar>().AddScore(4);
                    }
                    else if (placement == 1)
                    {
                        finishOrder[placement].GetComponent<movementPilar>().AddScore(3);
                    }
                    else if (placement == 2)
                    {
                        finishOrder[placement].GetComponent<movementPilar>().AddScore(2);
                    }
                    placement++;
                    UpdateScoreText();
                }
                if (placement == 3)
                {
                    foreach (GameObject player in players)
                    {
                        if (player.GetComponent<movementPilar>().finished == false)
                        {
                            player.GetComponent<movementPilar>().finished = true;
                            player.GetComponent<movementPilar>().AddScore(1);
                        }
                    }
                    UpdateScoreText();
                }
                break;
        }

    }

   


    private void UpdateScoreText()
    {
        switch (numberPlayers)
        {
            case NumberPlayers.one:

                scoreText.text = "";
                for (int i = 0; i < 1; i++)
                {
                    scoreText.text += "Player " + (i + 1) + ": " + players[i].GetComponent<movementPilar>().totalScore + "\n";

                }
                break;


            case NumberPlayers.two:

                scoreText.text = "";

                for (int i = 0; i < 2; i++)
                {
                    scoreText.text += "Player " + (i + 1) + ": " + players[i].GetComponent<movementPilar>().totalScore + "\n";
                }
                break;

            case NumberPlayers.three:

                scoreText.text = "";

                for (int i = 0; i < 3; i++)
                {
                    scoreText.text += "Player " + (i + 1) + ": " + players[i].GetComponent<movementPilar>().totalScore + "\n";
                }
                break;

            case NumberPlayers.four:

                scoreText.text = "";

                for (int i = 0; i < 4; i++)
                {
                    scoreText.text += "Player " + (i + 1) + ": " + players[i].GetComponent<movementPilar>().totalScore + "\n";
                }
                break;

        }


        
    }
}
