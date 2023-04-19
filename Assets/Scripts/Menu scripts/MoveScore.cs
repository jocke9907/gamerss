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
        playerManager = FindObjectOfType<PlayerManager>();
        
    }

    public void MoveBlock()
    {


        PlayerController[] player = playerManager.GetPlayers().ToArray();
      
        foreach (PlayerController player1 in player)
        {
            

            if (pl1)
            {
                height = player[0].totalScore;
                y = -10.5f;
            }
            if (pl2)
            {
                if (playerController.playerTwo)
                {
                    height = player[1].totalScore;
                    y = -3.5f;
                }
            }
            if (pl3 )
            {
                if (playerController.playerThree)
                {
                    height = player[2].totalScore;
                    y = 3.5f;
                }
            }
            if (pl4)
            {
                if (playerController.playerFour)
                {
                    height = player[3].totalScore;
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
