using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScore : MonoBehaviour
{

    PlayerController playerController;
    PlayerLevel playerLevel;
    PlayerScore playerScore;
   [SerializeField] int height;
    public void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerLevel = FindObjectOfType<PlayerLevel>();
        playerScore = FindObjectOfType<PlayerScore>();
    }

    public void MoveBlock()
    {
       
        //playerScore.currentScore = height;
         height = playerController.totalScore;
    }
    public void Update()
    {
        MoveBlock();
        transform.position = new Vector3(-10.5f,(height) -5,8);
    }
}
