using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nrPlayers : MonoBehaviour
{
    public enum NumberOfPlayers { one, two, three, four }
    public NumberOfPlayers numberPlayers;

    //public GameObject[] player;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    scoreSystem1 system1;
    scoreSystem2 system2;

    public int playerCount;
    // Start is called before the first frame update
    void Start()
    {
        system1 = FindObjectOfType<scoreSystem1>();
        system2 = FindObjectOfType<scoreSystem2>();

        //player1 = GameObject.Find("Player1");
        //player2 = GameObject.Find("Player2");
        //player3 = GameObject.Find("Player3");
        //player4 = GameObject.Find("Player4");

        if (playerCount == 1)
        {
            numberPlayers = NumberOfPlayers.one;
        }
        if (playerCount == 2)
        {
            numberPlayers = NumberOfPlayers.two;
        }
        if (playerCount == 3)
        {
            numberPlayers = NumberOfPlayers.three;
        }
        if (playerCount == 4)
        {
            numberPlayers = NumberOfPlayers.four;
        }

        //player = GameObject.FindGameObjectsWithTag("Player");
        switch (numberPlayers)
        {
            case NumberOfPlayers.one:

                //player1.SetActive(false);
                //player2.SetActive(false);
                //player3.SetActive(false);
                //player4.SetActive(false);
                system1.numberPlayers = scoreSystem1.NumberPlayers.one;
                //system2.numberPlayers = scoreSystem2.NumberPlayers.one;


                break;

            case NumberOfPlayers.two:

                //player3.SetActive(false);
                //player4.SetActive(false);
                system1.numberPlayers = scoreSystem1.NumberPlayers.two;
                //system2.numberPlayers = scoreSystem2.NumberPlayers.two;


                break;

            case NumberOfPlayers.three:

                //player4.SetActive(false);
                system1.numberPlayers = scoreSystem1.NumberPlayers.three;
                //system2.numberPlayers = scoreSystem2.NumberPlayers.three;


                break;

            case NumberOfPlayers.four:

                system1.numberPlayers = scoreSystem1.NumberPlayers.four;
                //system2.numberPlayers = scoreSystem2.NumberPlayers.four;


                break;
        }
    }
}
