using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] players;


    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    bool spawned = false;

    //public enum NumberPlayers { one, two, three, four }
    //public NumberPlayers numberPlayers = NumberPlayers.one;

    private void Start()
    {
        //numberPlayers = (NumberPlayers)FindObjectOfType<nrPlayers>().playerCount - 1; //sätter värden på enum med int
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");

        players[0] = player1;
        players[1] = player2;
        players[2] = player3;
        players[3] = player4;

        players[0].gameObject.transform.position = new Vector3(-17, 2, -13);
        players[0].gameObject.transform.position = new Vector3(18, 2, -13);
        players[0].gameObject.transform.position = new Vector3(-6, 2, -13);
        players[0].gameObject.transform.position = new Vector3(6, 2, -13);

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
}
