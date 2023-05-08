using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
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
        ShowNexMap();
        Instruction();
        ShowPlayerScore();
    }

    public void ShowPlayerScore()
    {
        PlayerController[] players = playerManager.GetPlayers().ToArray();

        foreach (PlayerController player in players)
        {
            player1.text = players[0].totalScore.ToString();
            player2.text = players[1].totalScore.ToString();
            player3.text = players[2].totalScore.ToString();
            player4.text = players[3].totalScore.ToString();

        }
    }
    public void Instruction()
    {
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
        if(randomMap.randMap == 1)
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
}
