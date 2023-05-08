using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreSystem2 : MonoBehaviour
{
    public GameObject[] players;



    GameObject player1;
    GameObject player2;
    GameObject player3;
    GameObject player4;

    public TMP_Text scoreText;
    string playerName;
    int placement = 0;

    private List<GameObject> finishOrder = new List<GameObject>();
    private List<GameObject> playerScore = new List<GameObject>();
    public enum NumberPlayers { one, two, three, four }
    public NumberPlayers numberPlayers = NumberPlayers.one;

    private void Start()
    {
        numberPlayers = (NumberPlayers)FindObjectOfType<nrPlayers>().playerCount - 1; //sätter värden på enum med int
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");

        players[0] = player1;
        players[1] = player2;
        players[2] = player3;
        players[3] = player4;
        UpdateScoreText();
    }
    private void OnTriggerEnter(Collider other)
    {

        switch (numberPlayers)
        {
            case NumberPlayers.one:


                if (other.CompareTag("Player") && other.GetComponent<PlayerController>().finished == false)
                {
                    other.GetComponent<PlayerController>().finished = true;

                    finishOrder.Add(other.gameObject);

                    finishOrder[placement].GetComponent<PlayerController>().AddScore(1);


                    UpdateScoreText();
                }
                break;

            case NumberPlayers.two:

                if (other.CompareTag("Player") && other.GetComponent<PlayerController>().finished == false)
                {
                    other.GetComponent<PlayerController>().finished = true;
                    finishOrder.Add(other.gameObject);

                    if (placement == 0)
                    {
                        finishOrder[placement].GetComponent<PlayerController>().AddScore(1);
                    }
                    placement++;
                    UpdateScoreText();
                }

                if (placement == 1)
                {
                    foreach (GameObject player in players)
                    {
                        if (!player)
                        {
                            continue; //går till nästa objekt i foreach loopen.
                        }
                        if (player.CompareTag("Player") && player.GetComponent<PlayerController>().finished == false)
                        {
                            player.GetComponent<PlayerController>().finished = true;
                            player.GetComponent<PlayerController>().AddScore(2);

                        }
                    }
                    UpdateScoreText();
                }
                break;

            case NumberPlayers.three:

                if (other.CompareTag("Player") && other.GetComponent<PlayerController>().finished == false)
                {
                    other.GetComponent<PlayerController>().finished = true;

                    finishOrder.Add(other.gameObject);


                    if (placement == 0)
                    {
                        finishOrder[placement].GetComponent<PlayerController>().AddScore(1);
                    }
                    else if (placement == 1)
                    {
                        finishOrder[placement].GetComponent<PlayerController>().AddScore(2);
                    }
                    placement++;
                    UpdateScoreText();
                }
                if (placement == 2)
                {
                    foreach (GameObject player in players)
                    {
                        if (!player)
                        {
                            continue; //går till nästa objekt i foreach loopen.
                        }
                        if (player.GetComponent<PlayerController>().finished == false)
                        {
                            player.GetComponent<PlayerController>().finished = true;
                            player.GetComponent<PlayerController>().AddScore(3);
                        }
                    }
                    UpdateScoreText();
                }
                break;

            case NumberPlayers.four:

                if (other.CompareTag("Player") && other.GetComponent<PlayerController>().finished == false)
                {
                    other.GetComponent<PlayerController>().finished = true;

                    finishOrder.Add(other.gameObject);


                    if (placement == 0)
                    {
                        finishOrder[placement].GetComponent<PlayerController>().AddScore(1);
                    }
                    else if (placement == 1)
                    {
                        finishOrder[placement].GetComponent<PlayerController>().AddScore(2);
                    }
                    else if (placement == 2)
                    {
                        finishOrder[placement].GetComponent<PlayerController>().AddScore(3);
                    }
                    placement++;
                    UpdateScoreText();
                }
                if (placement == 3)
                {
                    foreach (GameObject player in players)
                    {
                        if (!player)
                        {
                            continue; //går till nästa objekt i foreach loopen.
                        }
                        if (player.GetComponent<PlayerController>().finished == false)
                        {
                            player.GetComponent<PlayerController>().finished = true;
                            player.GetComponent<PlayerController>().AddScore(4);
                        }
                    }
                    UpdateScoreText();
                }
                break;
        }

    }

    public void UpdateScoreText()
    {
        switch (numberPlayers)
        {
            case NumberPlayers.one:

                scoreText.text = "";
                for (int i = 0; i < 1; i++)
                {
                    if (i == 0)
                    {
                        playerName = "Blue";
                    }
                    else if (i == 1)
                    {
                        playerName = "Green";
                    }
                    else if (i == 2)
                    {
                        playerName="Yellow";
                    }
                    else if (i == 3)
                    {
                        playerName = "Red";
                    }

                    scoreText.text += playerName + ": " + players[i].GetComponent<PlayerController>().tempScore + "\n";

                }
                break;


            case NumberPlayers.two:

                scoreText.text = "";

                for (int i = 0; i < 2; i++)
                {
                    if (i == 0)
                    {
                        playerName = "Blue";
                    }
                    else if (i == 1)
                    {
                        playerName = "Green";
                    }
                    else if (i == 2)
                    {
                        playerName = "Yellow";
                    }
                    else if (i == 3)
                    {
                        playerName = "Red";
                    }

                    scoreText.text += playerName + ": " + players[i].GetComponent<PlayerController>().tempScore + "\n";

                }
                break;

            case NumberPlayers.three:

                scoreText.text = "";

                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                    {
                        playerName = "Blue";
                    }
                    else if (i == 1)
                    {
                        playerName = "Green";
                    }
                    else if (i == 2)
                    {
                        playerName = "Yellow";
                    }
                    else if (i == 3)
                    {
                        playerName = "Red";
                    }

                    scoreText.text += playerName + ": " + players[i].GetComponent<PlayerController>().tempScore + "\n";

                }
                break;

            case NumberPlayers.four:

                scoreText.text = "";
                for (int i = 0; i < 4; i++)
                {
                    if (i == 0)
                    {
                        playerName = "Blue";
                    }
                    else if (i == 1)
                    {
                        playerName = "Green";
                    }
                    else if (i == 2)
                    {
                        playerName = "Yellow";
                    }
                    else if (i == 3)
                    {
                        playerName = "Red";
                    }

                    scoreText.text += playerName + ": " + players[i].GetComponent<PlayerController>().tempScore + "\n";

                }
                break;

        }



    }
}
