using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BomberScript : MonoBehaviour
{
    public int playerLeft ;
    PlayerManager playerManager;
    public TextMeshProUGUI players;
    public TextMeshProUGUI playerCollor1;
    public TextMeshProUGUI playerCollor2;
    public TextMeshProUGUI playerCollor3;
    public TextMeshProUGUI playerCollor4;
    public TextMeshProUGUI winner;
    PlayerScore playerScore;
    PlayerController playerController;
    private Thread trd;
    public  float targetTime1 = 4.0f;
    string player1Collor;
    string player2Collor;
    string player3Collor;
    string player4Collor;
    string dead1 = " alive";
    string dead2 = " alive";
    string dead3 = " alive";
    string dead4 = " alive";
    bool checkCollor = true;
    BomberManger bomberManger;
    public void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        bomberManger = FindObjectOfType<BomberManger>();
        playerManager = FindObjectOfType<PlayerManager>();
    }
   

    // Update is called once per frame
    void Update()
    {
        bomberManger.GetComponent<BomberManger>();

        ShowPlayerCollor();
        CheckDead();

        if (checkCollor)
        {
            
        }
        
        playerLeft = bomberManger.playerCountBomber;
        players.text = "Players left " + (playerLeft + 1);

        playerCollor1.text =  player1Collor + dead1 ;
        playerCollor2.text = player2Collor + dead2 ;
        playerCollor3.text =  player3Collor + dead3 ;
        playerCollor4.text = player4Collor + dead4 ;
    }
    public void CheckDead()
    {
        PlayerController[] players = playerManager.GetPlayers().ToArray();
        if (bomberManger.nrOfPlayers == 2)
        {
            foreach (PlayerController player in players)
            {

                if (players[0].veryDead)
                {
                    dead1 = " dead!!!";
                }
                if (players[1].veryDead)
                {
                    dead2 = " dead!!!";
                }
                if (players[2].veryDead)
                {
                    dead3 = " dead!!!";
                }
                


            }
            dead4 = "";
        }
        else if (bomberManger.nrOfPlayers == 3)
        {
            foreach (PlayerController player in players)
            {
                if (players[0].veryDead)
                {
                    dead1 = " dead!!!";
                }
                if (players[1].veryDead)
                {
                    dead2 = " dead!!!";
                }
                if (players[2].veryDead)
                {
                    dead3 = " dead!!!";
                }
                if (players[3].veryDead)
                {
                    dead4 = " dead!!!";
                }


            }
        }
        else if (bomberManger.nrOfPlayers == 1)
        {
            foreach (PlayerController player in players)
            {

                if (players[0].veryDead)
                {
                    dead1 = " dead!!!";
                }
                if (players[1].veryDead)
                {
                    dead2 = " dead!!!";
                }

            }
            dead3 = "";
            dead4 = "";

        }
               
    }
    public void ShowPlayerCollor()
    {
        
        PlayerController[] players = playerManager.GetPlayers().ToArray();
        if (bomberManger.nrOfPlayers == 2)
        {
            foreach (PlayerController player in players)
            {
                if (players[0].playerOne)
                {
                    player1Collor = "Bleu";
                }
                else if (players[0].playerTwo)
                {
                    player1Collor = "Green";
                }
                else if (players[0].playerThree)
                {
                    player1Collor = "Yellow";
                }
                else if (players[0].playerFour)
                {
                    player1Collor = "Red";
                }

                if (players[1].playerOne)
                {
                    player2Collor = "Bleu";
                }
                else if (players[1].playerTwo)
                {
                    player2Collor = "Green";
                }
                else if (players[1].playerThree)
                {
                    player2Collor = "Yellow";
                }
                else if (players[1].playerFour)
                {
                    player2Collor = "Red";
                }

                if (players[2].playerOne)
                {
                    player3Collor = "Bleu";
                }
                else if (players[2].playerTwo)
                {
                    player3Collor = "Green";
                }
                else if (players[2].playerThree)
                {
                    player3Collor = "Yellow";
                }
                else if (players[2].playerFour)
                {
                    player3Collor = "Red";
                }

            }
        }
        else if (bomberManger.nrOfPlayers == 3)
        {
            foreach (PlayerController player in players)
            {
                if (players[0].playerOne)
                {
                    player1Collor = "Bleu";
                }
                else if (players[0].playerTwo)
                {
                    player1Collor = "Green";
                }
                else if (players[0].playerThree)
                {
                    player1Collor = "Yellow";
                }
                else if (players[0].playerFour)
                {
                    player1Collor = "Red";
                }

                if (players[1].playerOne)
                {
                    player2Collor = "Bleu";
                }
                else if (players[1].playerTwo)
                {
                    player2Collor = "Green";
                }
                else if (players[1].playerThree)
                {
                    player2Collor = "Yellow";
                }
                else if (players[1].playerFour)
                {
                    player2Collor = "Red";
                }

                if (players[2].playerOne)
                {
                    player3Collor = "Bleu";
                }
                else if (players[2].playerTwo)
                {
                    player3Collor = "Green";
                }
                else if (players[2].playerThree)
                {
                    player3Collor = "Yellow";
                }
                else if (players[2].playerFour)
                {
                    player3Collor = "Red";
                }

                if (players[3].playerOne)
                {
                    player4Collor = "Bleu";
                }
                else if (players[3].playerTwo)
                {
                    player4Collor = "Green";
                }
                else if (players[3].playerThree)
                {
                    player4Collor = "Yellow";
                }
                else if (players[3].playerFour)
                {
                    player4Collor = "Red";
                }

            }
        }
        else if (bomberManger.nrOfPlayers == 1)
        {
            foreach (PlayerController player in players)
            {
                if (players[0].playerOne)
                {
                    player1Collor = "Bleu";
                }
                else if (players[0].playerTwo)
                {
                    player1Collor = "Green";
                }
                else if (players[0].playerThree)
                {
                    player1Collor = "Yellow";
                }
                else if (players[0].playerFour)
                {
                    player1Collor = "Red";
                }

                if (players[1].playerOne)
                {
                    player2Collor = "Bleu";
                }
                else if (players[1].playerTwo)
                {
                    player2Collor = "Green";
                }
                else if (players[1].playerThree)
                {
                    player2Collor = "Yellow";
                }
                else if (players[1].playerFour)
                {
                    player2Collor = "Red";
                }
            }
        }
        checkCollor = false;
    }
    public void Winner()
    {
        winner.text = "The winner is ---- \nSecond place ----";
        bomberManger.changeGame = true;
    }
}

