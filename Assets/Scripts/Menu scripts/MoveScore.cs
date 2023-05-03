using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MoveScore : MonoBehaviour
{

    PlayerController playerController;
    PlayerManager playerManager;
    PlayerLevel playerLevel;
    PlayerScore playerScore;
    [SerializeField] float height;
    [SerializeField] bool pl1s;
    [SerializeField] bool pl2s;
    [SerializeField] bool pl3s;
    [SerializeField] bool pl4s;
    float x;
    float z;
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
            

            if (pl1s && players.Length > 1)
            {
                height = players[0].totalScore - 0.1f;
                
                x = -2.5f;
                z = 2.5f;
                CollorPillar(players[0]);
            }
            if (pl2s && players.Length > 2)
            {
               
                height = players[1].totalScore - 0.1f;
                x = 2.5f;
                z = -2.5f;
                CollorPillar(players[1]);

            }
            if (pl3s && players.Length > 3)
            {
                height = players[2].totalScore - 0.1f;
                x = -2.5f;
                z = -2.5f;
                CollorPillar(players[2]);
            }
            if (pl4s && players.Length > 4)
            {
                height = players[3].totalScore - 0.1f;
                x = 2.5f;
                z = 2.5f;
                CollorPillar(players[3]);
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
        transform.position = new Vector3(x, (height) - 5.1f, z);
        

    }
    public void CollorPillar(PlayerController player)
    {

        if (player.playerOne)
        {
            GetComponent<Renderer>().material.color = Color.blue;

        }
        else if(player.playerTwo)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if (player.playerThree)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (player.playerFour)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }

       
    }
}
