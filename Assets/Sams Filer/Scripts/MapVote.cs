using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapVote : MonoBehaviour
{

    //---------------WRITTEN BY SAM-------------------

    //This script does three things:

    // 1. It allows players to vote which minigame should be chosen next
    // 2. After chossing a minigame, it switches to that specific scene.
    // 3. It checks how many rounds has been played. Upon reaching a set amount of games, a winner will be declared.

    // The voting system is made of two scripts. Please check the "selectMap" script first before reading this one.

    // This scripts starts when every player stands on a pillar.
    // Upon start, a countdown starts from 5 seconds. Players have to stand on their respective pillar for 5 whole seconds before the script takes effect.
    // Should anyone jump off their pillar before that, the countdown resets and starts when everyone has chosen a pillar again.
    // Should the countdown reach 0, it will start the voting phase.
    // In this phase, the script firstly checks how many players have joined, and chooses one of these players with RNG, each one having equally big of a chance to be chosen.
    // When the script has chosen a player. It checks what minigame said player have chosen by looking in <Playercontroller> script and checking the variables "MapChosen" and "MapChosenString"
    // It checks to see what number "MapChosen" has, and uses this variable in the if-statement to see which map has been chosen, and switches to that scene.

    // Upon reaching the winning condition round, the script will also check which players has the highest score, and will afterwards display that 
    // in a 3d text on the map. Should 1st place and 2nd have the same amount of score, both are declared winners.







    BomberManger bomberManger;

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
    bool winnerActivated = false;


    GameObject player1;
    GameObject player2;
    GameObject player3;
    GameObject player4;

    [SerializeField] TMP_Text textCountDown;
    [SerializeField] TMP_Text textSelectedMap;
    [SerializeField] TMP_Text textWinner;
    [SerializeField] TMP_Text textNrGames;
    [SerializeField] int nrGames;
    float sceneCountDown = 3;
    int bestScore;
    string winner;
    bool gameOver = false;

    bool startCountDown = false;
    PlayerManager manager;

    public enum NumberPlayers { one, two, three, four }
    public NumberPlayers numberPlayers = NumberPlayers.one;

    void Start()
    {

        //--------------ARVID------------------------------------------------

        bomberManger = FindObjectOfType<BomberManger>();

        manager = FindObjectOfType<PlayerManager>();

        foreach (PlayerController player in manager.GetPlayers())
        {
            player.veryDead = false;
            //player.gameObject.SetActive(true);
        }
        //-------------------------------------------------------------------

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

        foreach (GameObject player in players)
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
                bomberManger.playerCountBomber = 1; //ARVID
                bomberManger.giveScore = 2;
                bomberManger.bomberPoints = 2;

                break;

            case NumberPlayers.three:

                nrPlayers = 3;
                bomberManger.playerCountBomber = 2; //ARVID
                bomberManger.giveScore = 3;
                bomberManger.bomberPoints = 3;

                break;
            case NumberPlayers.four:

                nrPlayers = 4;
                bomberManger.playerCountBomber = 3; //ARVID
                bomberManger.giveScore = 4;
                bomberManger.bomberPoints = 4;

                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        textNrGames.text = "Round " + manager.gamesPlayed.ToString() + "/" + nrGames.ToString();


        if (manager.gamesPlayed == nrGames)
        {

            ScoreResult();
        }
        textCountDown.text = ((int)countDown).ToString();
        textSelectedMap.text = mapChosenString;
        checkIfPlayersReady();


        if (voteOver == true)
        {
            countDown = 0;
        }

        if (startCountDown == true || voteOver == true)
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
            choosePlayer = Random.Range(0, nrPlayers);
            mapChosen = players[choosePlayer].GetComponent<PlayerController>().mapSelectedInt;
            mapChosenString = players[choosePlayer].GetComponent<PlayerController>().mapSelected;
        }


        sceneCountDown -= Time.deltaTime;

        if (sceneCountDown <= 0)
        {
            manager.gamesPlayed++;
            if (mapChosen == 0)
            {

                mapChosen = Random.Range(1, 8);
            }

            if (mapChosen == 1)
            {
                Loader.PlatformGamePlaying = true;
                Loader.Load(Loader.Scene.ViggesScene);
            }
            else if (mapChosen == 2)
            {
                Loader.TheMazePlaying = true;
                Loader.Load(Loader.Scene.TheMaze);
            }
            else if (mapChosen == 3)
            {
                Loader.wallClimberPlaying = true;
                Loader.Load(Loader.Scene.SamScen);
            }
            else if (mapChosen == 4)
            {
                bomberManger.redusePlayers = false;
                //bomberManger.bomberPlayed = true;
                bomberManger.GameStart();
                //bomberManger.bomberPoints = 4;
                bomberManger.bomberPlayed = true;
                Loader.bomberGamePlaying = true;

                Loader.Load(Loader.Scene.BomberGame);
            }
            else if (mapChosen == 5)
            {
                Loader.captureTheFlagPlaying = true;
                Loader.Load(Loader.Scene.CaptureTheFlag);
            }
            else if (mapChosen == 6)
            {
                Loader.spinningWheelPlaying = true;
                Loader.Load(Loader.Scene.SpinningWheel);
            }
            else if (mapChosen == 7)
            {
                bomberManger.redusePlayers = false;
                //bomberManger.lavaGroundPlayed = true;
                bomberManger.GameStart();
                //bomberManger.bomberPoints = 4;
                bomberManger.lavaGroundPlayed = true;
                Loader.LavaGroundPlaying = true;
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
    private void ScoreResult()
    {

        //gameOver = true;
        //bestScore = players[0].GetComponent<PlayerController>().totalScore;
        //winner = "Player1";
        //foreach (GameObject player in players)
        //{
        //    if (!player)
        //    {
        //        continue;
        //    }
        //    if (player.GetComponent<PlayerController>().totalScore > bestScore)
        //    {
        //        bestScore = player.GetComponent<PlayerController>().totalScore;
        //        winner = player.transform.name;
        //    }
        //}


        //if (winner == "Player1")
        //{
        //    winner = "Blue";
        //}
        //else if (winner == "Player2")
        //{
        //    winner = "Green";
        //}
        //else if (winner == "Player3")
        //{
        //    winner = "Yellow";
        //}
        //else if (winner == "Player4")
        //{
        //    winner = "Red";
        //}
        //textWinner.text = winner + " is the ultimate color!";






        switch (numberPlayers)
        {
            case NumberPlayers.two:

                gameOver = true;
                bestScore = players[0].GetComponent<PlayerController>().totalScore;
                winner = "Player1";
                foreach (GameObject player in players)
                {
                    if (!player)
                    {
                        continue;
                    }
                    if (player.GetComponent<PlayerController>().totalScore > bestScore)
                    {
                        bestScore = player.GetComponent<PlayerController>().totalScore;
                        winner = player.transform.name;
                    }
                }
                if (winner == "Player1")
                {
                    winner = "Blue";
                    if (players[0].GetComponent<PlayerController>().totalScore == players[1].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Blue and Green are equally nice colors!";
                        break;
                    }
                }
                else if (winner == "Player2")
                {
                    winner = "Green";
                    if (players[1].GetComponent<PlayerController>().totalScore == players[0].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Green and Blue are equally nice colors!";
                        break;
                    }
                }

                textWinner.text = winner + " is the ultimate color!";
                break;



            case NumberPlayers.three:


                gameOver = true;
                bestScore = players[0].GetComponent<PlayerController>().totalScore;
                winner = "Player1";
                foreach (GameObject player in players)
                {
                    if (!player)
                    {
                        continue;
                    }
                    if (player.GetComponent<PlayerController>().totalScore > bestScore)
                    {
                        bestScore = player.GetComponent<PlayerController>().totalScore;
                        winner = player.transform.name;
                    }
                }
                if (winner == "Player1")
                {
                    winner = "Blue";
                    if (players[0].GetComponent<PlayerController>().totalScore == players[1].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Blue and Green are equally nice colors!";
                        break;
                    }
                    else if (players[0].GetComponent<PlayerController>().totalScore == players[2].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Blue and Yellow are equally nice colors!";
                        break;
                    }

                }
                else if (winner == "Player2")
                {
                    winner = "Green";
                    if (players[1].GetComponent<PlayerController>().totalScore == players[0].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Green and Blue are equally nice colors!";
                        break;
                    }
                    else if (players[1].GetComponent<PlayerController>().totalScore == players[2].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Green and Yellow are equally nice colors!";
                        break;
                    }
                }
                else if (winner == "Player3")
                {
                    winner = "Yellow";
                    if (players[2].GetComponent<PlayerController>().totalScore == players[0].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Yellow and Blue are equally nice colors!";
                        break;
                    }
                    else if (players[2].GetComponent<PlayerController>().totalScore == players[1].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Yellow and Green are equally nice colors!";
                        break;
                    }
                }

                textWinner.text = winner + " is the ultimate color!";
                break;



            case NumberPlayers.four:


                gameOver = true;
                bestScore = players[0].GetComponent<PlayerController>().totalScore;
                winner = "Player1";
                foreach (GameObject player in players)
                {
                    if (!player)
                    {
                        continue;
                    }
                    if (player.GetComponent<PlayerController>().totalScore > bestScore)
                    {
                        bestScore = player.GetComponent<PlayerController>().totalScore;
                        winner = player.transform.name;
                    }
                }
                if (winner == "Player1")
                {
                    winner = "Blue";
                    if (players[0].GetComponent<PlayerController>().totalScore == players[1].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Blue and Green are equally nice colors!";
                        break;
                    }
                    else if (players[0].GetComponent<PlayerController>().totalScore == players[2].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Blue and Yellow are equally nice colors!";
                        break;
                    }
                    else if (players[0].GetComponent<PlayerController>().totalScore == players[3].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Blue and Red are equally nice colors!";
                        break;
                    }

                }
                else if (winner == "Player2")
                {
                    winner = "Green";
                    if (players[1].GetComponent<PlayerController>().totalScore == players[0].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Green and Blue are equally nice colors!";
                        break;
                    }
                    else if (players[1].GetComponent<PlayerController>().totalScore == players[2].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Green and Yellow are equally nice colors!";
                        break;
                    }
                    else if (players[1].GetComponent<PlayerController>().totalScore == players[3].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Green and Red are equally nice colors!";
                        break;
                    }
                }
                else if (winner == "Player3")
                {
                    winner = "Yellow";
                    if (players[2].GetComponent<PlayerController>().totalScore == players[0].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Yellow and Blue are equally nice colors!";
                        break;
                    }
                    else if (players[2].GetComponent<PlayerController>().totalScore == players[1].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Yellow and Green are equally nice colors!";
                        break;
                    }
                    else if (players[2].GetComponent<PlayerController>().totalScore == players[3].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Yellow and Red are equally nice colors!";
                        break;
                    }
                }
                else if (winner == "Player4")
                {
                    winner = "Red";
                    if (players[3].GetComponent<PlayerController>().totalScore == players[0].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Red and Blue are equally nice colors!";
                        break;
                    }
                    else if (players[3].GetComponent<PlayerController>().totalScore == players[1].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Red and Green are equally nice colors!";
                        break;
                    }
                    else if (players[3].GetComponent<PlayerController>().totalScore == players[2].GetComponent<PlayerController>().totalScore)
                    {
                        textWinner.text = "Red and Yellow are equally nice colors!";
                        break;
                    }
                }
                textWinner.text = winner + " is the ultimate color!";

                break;
        }
    }
}
