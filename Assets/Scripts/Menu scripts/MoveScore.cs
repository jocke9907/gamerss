using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScore : MonoBehaviour
{

    PlayerController playerController;
    PlayerLevel playerLevel;
    PlayerScore playerScore;
    [SerializeField] int height;
    [SerializeField] bool pl1;
    [SerializeField] bool pl2;
    [SerializeField] bool pl3;
    [SerializeField] bool pl4;
    float y;
    public void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerLevel = FindObjectOfType<PlayerLevel>();
        playerScore = FindObjectOfType<PlayerScore>();
    }

    public void MoveBlock()
    {
        PlayerController[] players = FindObjectsOfType<PlayerController>();
        foreach (PlayerController player in players)
        {
            if (pl1)
            {
                height = players[0].totalScore;
                y = -10.5f;
            }
            if (pl2)
            {
                if (playerController.playerTwo)
                {
                    height = players[1].totalScore;
                    y = -3.5f;
                }
            }
            if (pl3)
            {
                if (playerController.playerThree)
                {
                    height = players[1].totalScore;
                    y = 3.5f;
                }
            }
            if (pl4)
            {
                if (playerController.playerFour)
                {
                    height = players[1].totalScore;
                    y = 10.5f;
                }
            }

        }
        //if (pl1)
        //{
        //    if (playerController.playerOne)
        //    {
        //        height = playerController.totalScore;
        //        y = -10.5f;
        //    }
        //}

        //if (pl2)
        //{
        //    if (playerController.playerTwo)
        //    {
        //        height = playerController.totalScore;
        //        y = -3.5f;
        //    }
        //}

        //if (pl3)
        //{
        //    if (playerController.playerThree)
        //    {
        //        height = playerController.totalScore;
        //        y = 3.5f;
        //    }
        //}

        //if (pl4)
        //{
        //    if (playerController.playerFour)
        //    {
        //        height = playerController.totalScore;
        //        y = 10.5f;
        //    }
        //}

        //playerScore.currentScore = height;

    }
    public void Update()
    {
        MoveBlock();
        transform.position = new Vector3(y, (height) - 5, 8);
        

    }
}
