using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CanvasScriptPost : MonoBehaviour
{
    PlayerController playerController;
    BomberManger bomberManger;
    RandomMap randomMap;
    public TextMeshProUGUI nextMap;
    public TextMeshProUGUI instructions;
    public TextMeshProUGUI player1;
    public TextMeshProUGUI player2;
    public TextMeshProUGUI player3;
    public TextMeshProUGUI player4;

    string player1Collor;
    string player2Collor;
    string player3Collor;
    string player4Collor;
    string winnerScore;
    int maxGames = 7;
    PlayerManager playerManager;
    public void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        bomberManger = FindObjectOfType<BomberManger>();
        randomMap = FindObjectOfType<RandomMap>();
        playerManager = FindObjectOfType<PlayerManager>();

    }
    void Update()
    {
        ShowPlayerCollor();
        ShowNexMap();
        Instruction();
        ShowPlayerScore();
        CheckWinner();
    }
    public void CheckWinner()
    {
        PlayerController[] players = playerManager.GetPlayers().ToArray();

        int maxInt = Int32.MinValue;
        int maxIndex = -1;
        for (int i = 0; i < players.Length; i++)
        {
            int value = players[i].totalScore;
            if (value > maxInt)
            {
                maxInt = value;
                maxIndex = i;


                if (players[maxIndex].playerOne)
                {
                    winnerScore = "Blue!!!";
                }
                else if (players[maxIndex].playerTwo)
                {
                    winnerScore = "Green!!!";
                }
                else if (players[maxIndex].playerThree)
                {
                    winnerScore = "Yellow!!!";
                }
                else if (players[maxIndex].playerFour)
                {
                    winnerScore = "Red!!!";
                }
            }
        }
        if (bomberManger.gamesPlayed > maxGames)
        {
            nextMap.text = "The Winner is " + winnerScore + "!!!";
        }
        Debug.Log(winnerScore);
       
    }
    public void ShowPlayerScore()
    {
        PlayerController[] players = playerManager.GetPlayers().ToArray();

        if (bomberManger.nrOfPlayers == 3)
        {
            foreach (PlayerController player in players)
            {
                player1.text = player1Collor + players[0].totalScore.ToString();
                player2.text = player2Collor + players[1].totalScore.ToString();
                player3.text = player3Collor + players[2].totalScore.ToString();
                player4.text = player4Collor + players[3].totalScore.ToString();

            }
        }
        if (bomberManger.nrOfPlayers == 2)
        {
            foreach (PlayerController player in players)
            {
                player1.text = player1Collor + players[0].totalScore.ToString();
                player2.text = player2Collor + players[1].totalScore.ToString();
                player3.text = player3Collor + players[2].totalScore.ToString();
               

            }
        }
        if (bomberManger.nrOfPlayers == 1)
        {
            foreach (PlayerController player in players)
            {
                player1.text = player1Collor + players[0].totalScore.ToString();
                player2.text = player2Collor + players[1].totalScore.ToString();
                

            }
        }

    }
    public void Instruction()
    {
        if (bomberManger.gamesPlayed >= maxGames)
        {
            return;
        }
        if (randomMap.randMap == 1)
        {
            // ground is falling
            instructions.text = " Dodge the falling platforms";
        }
        if (randomMap.randMap == 2)
        {
            // bomber
            instructions.text = "Kill the enemy with bombs. Press E/X to place bomb. ";
        }
        if (randomMap.randMap == 3)
        {
            // The Maze
            instructions.text = "Run to the center of the maze ";
        }
        if (randomMap.randMap == 4)
        {
            // Wall climber
            instructions.text = "Climb over the wall. Press K/X to grab.";
        }
        if (randomMap.randMap == 5)
        {
            // Ground is Lava
            instructions.text = "Run from the lava ";
        }
        if (randomMap.randMap == 6)
        {
            //Capture the flag
            instructions.text = "Take the flags and put them in the corners ";
        }
        if (randomMap.randMap == 7)
        {
            //spinning wheel
            instructions.text = "Survive ";
        }
    }
    public void ShowNexMap()
    {

        if (bomberManger.gamesPlayed >= maxGames)
        {
            return;
        }

        if (randomMap.randMap == 1)
        {
            nextMap.text = "The next map is Ground is Falling. ";
        }
        if (randomMap.randMap == 2)
        {
            nextMap.text = "The next map is Bomber. ";
        }
        if (randomMap.randMap == 3)
        {
            nextMap.text = "The next map is The Maze. ";
        }
        if (randomMap.randMap == 4)
        {
            nextMap.text = "The next map is Wall Climber. ";
        }
        if (randomMap.randMap == 5)
        {
            nextMap.text = "The next map is Ground is Lava. ";
        }
        if (randomMap.randMap == 6)
        {
            nextMap.text = "The next map is Capture the Flag. ";
        }
        if (randomMap.randMap == 7)
        {
            nextMap.text = "The next map is Spinning Wheel. ";
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
                    player1Collor = "Blue ";
                }
                else if (players[0].playerTwo)
                {
                    player1Collor = "Green ";
                }
                else if (players[0].playerThree)
                {
                    player1Collor = "Yellow ";
                }
                else if (players[0].playerFour)
                {
                    player1Collor = "Red ";
                }

                if (players[1].playerOne)
                {
                    player2Collor = "Blue  ";
                }
                else if (players[1].playerTwo)
                {
                    player2Collor = "Green ";
                }
                else if (players[1].playerThree)
                {
                    player2Collor = "Yellow ";
                }
                else if (players[1].playerFour)
                {
                    player2Collor = "Red ";
                }

                if (players[2].playerOne)
                {
                    player3Collor = "Blue ";
                }
                else if (players[2].playerTwo)
                {
                    player3Collor = "Green ";
                }
                else if (players[2].playerThree)
                {
                    player3Collor = "Yellow ";
                }
                else if (players[2].playerFour)
                {
                    player3Collor = "Red ";
                }

            }
        }
        else if (bomberManger.nrOfPlayers == 3)
        {
            foreach (PlayerController player in players)
            {
                if (players[0].playerOne)
                {
                    player1Collor = "Blue ";
                }
                else if (players[0].playerTwo)
                {
                    player1Collor = "Green ";
                }
                else if (players[0].playerThree)
                {
                    player1Collor = "Yellow ";
                }
                else if (players[0].playerFour)
                {
                    player1Collor = "Red ";
                }

                if (players[1].playerOne)
                {
                    player2Collor = "Blue ";
                }
                else if (players[1].playerTwo)
                {
                    player2Collor = "Green ";
                }
                else if (players[1].playerThree)
                {
                    player2Collor = "Yellow ";
                }
                else if (players[1].playerFour)
                {
                    player2Collor = "Red ";
                }

                if (players[2].playerOne)
                {
                    player3Collor = "Blue ";
                }
                else if (players[2].playerTwo)
                {
                    player3Collor = "Green ";
                }
                else if (players[2].playerThree)
                {
                    player3Collor = "Yellow ";
                }
                else if (players[2].playerFour)
                {
                    player3Collor = "Red ";
                }

                if (players[3].playerOne)
                {
                    player4Collor = "Blue ";
                }
                else if (players[3].playerTwo)
                {
                    player4Collor = "Green ";
                }
                else if (players[3].playerThree)
                {
                    player4Collor = "Yellow ";
                }
                else if (players[3].playerFour)
                {
                    player4Collor = "Red ";
                }

            }
        }
        else if (bomberManger.nrOfPlayers == 1)
        {
            foreach (PlayerController player in players)
            {
                if (players[0].playerOne)
                {
                    player1Collor = "Blue ";
                }
                else if (players[0].playerTwo)
                {
                    player1Collor = "Green ";
                }
                else if (players[0].playerThree)
                {
                    player1Collor = "Yellow ";
                }
                else if (players[0].playerFour)
                {
                    player1Collor = "Red ";
                }

                if (players[1].playerOne)
                {
                    player2Collor = "Blue ";
                }
                else if (players[1].playerTwo)
                {
                    player2Collor = "Green ";
                }
                else if (players[1].playerThree)
                {
                    player2Collor = "Yellow ";
                }
                else if (players[1].playerFour)
                {
                    player2Collor = "Red ";
                }

            }
        }
        //checkCollor = false;
    }
}
