using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnPostLobby : MonoBehaviour
{

    public GameObject spawnPlayer1;
    public GameObject spawnPlayer2;
    public GameObject spawnPlayer3;
    public GameObject spawnPlayer4;

    Vector3 player1Pos;
    Vector3 player2Pos;
    Vector3 player3Pos;
    Vector3 player4Pos;

    [SerializeField] TMP_Text scoreText1;
    [SerializeField] TMP_Text scoreText2;
    [SerializeField] TMP_Text scoreText3;
    [SerializeField] TMP_Text scoreText4;

    bool hasSpawned = false;





    private void Start()
    {
        player1Pos = spawnPlayer1.transform.position;
        player2Pos = spawnPlayer2.transform.position;
        player3Pos = spawnPlayer3.transform.position;
        player4Pos = spawnPlayer4.transform.position;

    }

    private void FixedUpdate()
    {
        if (hasSpawned == false)
        {
            PlayerController[] players = FindObjectsOfType<PlayerController>();
            foreach (PlayerController player in players)
            {
                if (player.gameObject.name == "Player1")
                {
                    player1Pos.y = (float)player.GetComponent<PlayerController>().totalScore / 2 + 2;
                    player.gameObject.transform.position = player1Pos;
                    player1Pos.y = (float)player1Pos.y - 1.8f;
                    scoreText1.transform.position = player1Pos;
                    scoreText1.text = player.GetComponent<PlayerController>().totalScore.ToString();
                }
                else if (player.gameObject.name == "Player2")
                {
                    player2Pos.y = (float)player.GetComponent<PlayerController>().totalScore / 2 + 2;
                    player.gameObject.transform.position = player2Pos;
                    player2Pos.y = (float)player2Pos.y - 1.8f;
                    scoreText2.transform.position = player2Pos;
                    scoreText2.text = player.GetComponent<PlayerController>().totalScore.ToString();
                }
                else if (player.gameObject.name == "Player3")
                {
                    player3Pos.y = (float)player.GetComponent<PlayerController>().totalScore / 2 + 2;
                    player.gameObject.transform.position = player3Pos;
                    player3Pos.y = (float)player3Pos.y - 1.8f;
                    scoreText3.transform.position = player3Pos;
                    scoreText3.text = player.GetComponent<PlayerController>().totalScore.ToString();
                }
                else if (player.gameObject.name == "Player4")
                {
                    player4Pos.y = (float)player.GetComponent<PlayerController>().totalScore / 2 + 2;
                    player.gameObject.transform.position = player4Pos;
                    player4Pos.y = (float)player4Pos.y - 1.8f;
                    scoreText4.transform.position = player4Pos;
                    scoreText4.text = player.GetComponent<PlayerController>().totalScore.ToString();
                }

                //Debug.Log("spawnPost");
            }
            hasSpawned = true;
        }

    }

}
