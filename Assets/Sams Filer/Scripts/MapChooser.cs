using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChooser : MonoBehaviour
{


    public TestMap pillarVoteSystem;
    public int pillarIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pillarVoteSystem.PlayerOnPillar(pillarIndex);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pillarVoteSystem.PlayerLeftPillar(pillarIndex);
        }
    }
    //public GameObject[] players;
    //GameObject player1;
    //GameObject player2;
    //GameObject player3;
    //GameObject player4;
    //public bool itWorks = false;

    //public enum NumberPlayers { one, two, three, four }
    //public NumberPlayers numberPlayers = NumberPlayers.one;
    //int playersRequired;
    //public int currentPlayersChosen = 0;

    //void Start()
    //{
    //    numberPlayers = (NumberPlayers)FindObjectOfType<nrPlayers>().playerCount - 1; //sätter värden på enum med int

    //    player1 = GameObject.Find("Player1");
    //    player2 = GameObject.Find("Player2");
    //    player3 = GameObject.Find("Player3");
    //    player4 = GameObject.Find("Player4");

    //    players[0] = player1;
    //    players[1] = player2;
    //    players[2] = player3;
    //    players[3] = player4;

    //    switch (numberPlayers)
    //    {
    //        case NumberPlayers.two:

    //            playersRequired = 2;

    //            break;

    //        case NumberPlayers.three:

    //            playersRequired = 3;

    //            break;

    //        case NumberPlayers.four:

    //            playersRequired = 4;

    //            break;

    //    }
    //}

    //// Update is called once per frame

    //private void OnTriggerEnter(Collider other)
    //{
    //    currentPlayersChosen++;
    //    while (currentPlayersChosen == playersRequired)
    //    {
    //        Debug.Log("it works");
    //    }
    //}

    ////private void OnTriggerExit(Collider other)
    ////{
    ////    currentPlayersChosen--;
    ////}
}
