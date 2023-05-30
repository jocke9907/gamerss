using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{

    //---------------WRITTEN BY SAM------------------------------------------

    // this script does 2 things. 
    // 1. It checks to see which players are still alive after the timer on specific minigames runs out.
    // When the timer runs it, it gives out 1 point to those who haven't finished in time.
    // Afterwards it changes scene to the postlobby.

    // 2. It checks to see how many players are left in the minigame. It automatically gives out points to the player
    // in last place when the player before him finishes, making it so players do not have to wait for the last player to finish.
    // afterwards it changes scene to postlobby

    // games that use this score script are mazerunner and wallclimber.
    public GameObject[] players;


    GameObject player1;
    GameObject player2;
    GameObject player3;
    GameObject player4;


    scoreSystem1 system1;


    public int playersRequired = 1;
    int playersFinished = 0;
    public float sceneTimer = 65f;
    public float scoreTimer = 60f;
    public float goalTimer = 5f;
    public bool timerActivated = false;
    bool sceneCountDown = false;
    GameObject hitObject;

    public enum NumberPlayers { one, two, three, four }
    public NumberPlayers numberPlayers = NumberPlayers.one;

    private void Start()
    {
        numberPlayers = (NumberPlayers)FindObjectOfType<nrPlayers>().playerCount - 1;
        playersRequired=FindObjectOfType<nrPlayers>().playerCount-1;

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");

        players[0] = player1;
        players[1] = player2;
        players[2] = player3;
        players[3] = player4;
    }


    private void OnTriggerEnter(Collider other)
    {
        switch (numberPlayers)
        {
            case NumberPlayers.one:

                hitObject = other.gameObject;
                if (hitObject.tag == "Player")
                {
                    sceneCountDown = true;

                }

                break;


            case NumberPlayers.two:

                hitObject = other.gameObject;
                if (hitObject.tag == "Player")
                {
                    playersFinished++;
                    if(playersFinished == playersRequired)
                    {
                        sceneCountDown = true;
                    }
                    

                }

                break;

            case NumberPlayers.three:

                hitObject = other.gameObject;
                if (hitObject.tag == "Player")
                {
                    playersFinished++;
                    if (playersFinished == playersRequired)
                    {
                        sceneCountDown = true;
                    }


                }

                break;

            case NumberPlayers.four:

                hitObject = other.gameObject;
                if (hitObject.tag == "Player")
                {
                    playersFinished++;
                    if (playersFinished == playersRequired)
                    {
                        sceneCountDown = true;
                    }


                }

                break;
        }


    }
   
    private void Update()
    {
        if (sceneCountDown == true)
        {
            goalTimer -= Time.deltaTime;
            if (goalTimer <= 0)
            {
                Loader.Load(Loader.Scene.PostLobby);
            }
        }
        sceneTimer -= Time.deltaTime;
        scoreTimer -= Time.deltaTime;
        if (scoreTimer <= 0 && timerActivated == true)
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
                    player.GetComponent<PlayerController>().AddScore(1);
                    system1 = FindObjectOfType<scoreSystem1>();
                    system1.UpdateScoreText();

                }
            }
        

        }
        if (sceneTimer <= 0 && timerActivated == true)
        {
            Loader.Load(Loader.Scene.PostLobby);
        }

    }
}
