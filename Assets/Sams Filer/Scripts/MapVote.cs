using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapVote : MonoBehaviour
{
    public GameObject[] pillarList;

    public GameObject[] players;
    //int nrPlayersReady = 0;

    int nrPlayers;
    int choosePlayer;
    int mapChosen;
    bool mapAlreadyChosen = false;
    string mapChosenString;
    public float countDown = 10;
    public float countDownLength = 10;
    bool voteOver = false;
  

    GameObject player1;
    GameObject player2;
    GameObject player3;
    GameObject player4;

    [SerializeField] TMP_Text textCountDown;
    [SerializeField] TMP_Text textSelectedMap;

    float sceneCountDown = 3;

    public bool startCountDown = false;

    public enum NumberPlayers { one, two, three, four }
    public NumberPlayers numberPlayers = NumberPlayers.one;

    void Start()
    {
        numberPlayers = (NumberPlayers)FindObjectOfType<nrPlayers>().playerCount - 1;
        

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");

        players[0] = player1;
        players[1] = player2;
        players[2] = player3;
        players[3] = player4;

        countDown = countDownLength;

        foreach(GameObject player in players)
        {
            if (!player)
            {
                continue;
            }
            player.GetComponent<PlayerController>().mapSelectedInt = -1;
            player.GetComponent<PlayerController>().mapSelected = "";
        }

        switch (numberPlayers)
        {
            case NumberPlayers.two:

                nrPlayers = 2;

                break;

            case NumberPlayers.three:

                nrPlayers = 3;

                break;
            case NumberPlayers.four:

                nrPlayers = 4;

                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        textCountDown.text = ((int)countDown).ToString();
        textSelectedMap.text = mapChosenString;
        checkIfPlayersReady();


        if (voteOver == true)
        {
            countDown = 0;
        }

        if (startCountDown == true || voteOver==true)
        {
            VotingMap();
            
        } 
        else
        {
            countDown = countDownLength;
        }


    }

    private void VotingMap()
    {
      

        if (voteOver == false)
        {
            countDown -= Time.deltaTime;
        }
        


        if (countDown <= 0)
        {
            voteOver = true;
            ChoosingMap();
        }
        checkIfPlayersReady();

        
    }

    private void ChoosingMap()
    {
        if (mapAlreadyChosen == false)
        {
            mapAlreadyChosen = true;
            choosePlayer = Random.Range(0, 2);
            mapChosen = players[choosePlayer].GetComponent<PlayerController>().mapSelectedInt;
            mapChosenString = players[choosePlayer].GetComponent<PlayerController>().mapSelected;
        }
        

        sceneCountDown -= Time.deltaTime;

        if (sceneCountDown <= 0)
        {
            if (mapChosen == 0)
            {
                
                mapChosen = Random.Range(1, 8);
            }

            if (mapChosen == 1)
            {
                Loader.Load(Loader.Scene.ViggesScene);
            }
            else if (mapChosen == 2)
            {
                Loader.Load(Loader.Scene.TheMaze);
            }
            else if (mapChosen == 3)
            {
                Loader.Load(Loader.Scene.SamScen);
            }
            else if (mapChosen == 4)
            {
                Loader.Load(Loader.Scene.BomberGame);
            }
            else if (mapChosen == 5)
            {
                Loader.Load(Loader.Scene.CaptureTheFlag);
            }
            else if (mapChosen == 6)
            {
                Loader.Load(Loader.Scene.SpinningWheel);
            }
            else if (mapChosen == 7)
            {
                Loader.Load(Loader.Scene.LavaGround);
            }
        }

       
    }

    private void checkIfPlayersReady()
    {
        int nrPlayersReady = 0;

        foreach (GameObject player in players)
        {
            if (!player)
            {
                continue; //går till nästa objekt i foreach loopen.
            }

            if (player.GetComponent<PlayerController>().mapSelectedInt != -1)
            {
                nrPlayersReady++;
            }

            if (nrPlayersReady == nrPlayers)
            {
                startCountDown = true;
            }
            else
            {
                startCountDown = false;
                
            }
        }
    }

}
