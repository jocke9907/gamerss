using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveScore : MonoBehaviour
{

    PlayerController playerController;
    PlayerManager playerManager;
    PlayerLevel playerLevel;
    PlayerScore playerScore;
    [SerializeField] int height;
    [SerializeField] bool pl1s;
    [SerializeField] bool pl2s;
    [SerializeField] bool pl3s;
    [SerializeField] bool pl4s;
    float y;
    public void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerLevel = FindObjectOfType<PlayerLevel>();
        playerScore = FindObjectOfType<PlayerScore>();
        playerManager = FindObjectOfType<PlayerManager>();
        
    }

    public void MoveBlock()
    {


        PlayerController[] players = playerManager.GetPlayers().ToArray();
      
        foreach (PlayerController player in players)
        {
            

            if (pl1s)
            {
                height = players[0].totalScore;
                
                y = -10.5f;
            }
            if (pl2s)
            {
               
                height = players[1].totalScore;
                y = -3.5f;
                //if (playerController.playerTwo)
                //{
                   
                //}
            }
            if (pl3s )
            {
                height = players[2].totalScore;
                y = 3.5f;
                if (playerController.playerThree)
                {
                   
                }
            }
            if (pl4s)
            {
                height = players[3].totalScore;
                y = 10.5f;
                if (playerController.playerFour)
                {
                   
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
