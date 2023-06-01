using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMan : MonoBehaviour
{



    // ------------------SCRIPT WRITTEN BY SAM----------------------------------------

//This script is responsible for controlling the camera in a game based on the number of players present in the scene.
//It adjusts the camera position, field of view (FOV), and zoom level based on the players' positions.

//Let's go through the script step by step:

//The script declares several public variables and objects:

// players is an array of GameObjects to store references to the players in the scene.
// player1, player2, player3, player4 are GameObject variables to assign specific players in the scene.
// cameraPos is a Vector3 variable to store the desired camera position.
// averageDistance is a float variable to calculate the average distance between players.
// minFOV and maxFOV are floats representing the minimum and maximum field of view values.
// zoom is a float representing the calculated zoom level.
// cam is a reference to the Camera component attached to the same GameObject as this script.
// distance is a float to store the calculated distance between players.
// numberPlayers is an enum representing the number of players in the scene.
// In the Start function:

//The cam variable is assigned the reference to the Camera component.
//The numberPlayers enum value is obtained from a nrPlayers object
//(which is an another script of mine that checks how many players are in game) and subtracted by 1.
//This is used to set the number of players based on a menu selection.

//In the Update function:

//A switch statement is used to handle different cases based on the number of players.
//For each case:
//The distance between the players is calculated using Vector3.Distance.
//The camera's fieldOfView is set to minFOV.
//The cameraPos variable is assigned a new Vector3 position based on the players' positions.
//Finally, the camera's position is set to cameraPos.
//The cases are as follows:

//Case NumberPlayers.one: For a single player, the camera position is set to the position of player 1, and no zoom is applied.

//Case NumberPlayers.two-four: For these states, the average distance between the players is calculated.The camera position is set to the midpoint between the players, and the zoom level is adjusted based on the average distance.





    public GameObject[] players;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public Vector3 cameraPos;

    float averageDistance;
    public float minFOV = 50f;
    public float maxFOV = 60f;
    float zoom;

    private Camera cam;

    float distance;
    public enum NumberPlayers { one, two, three, four }
    public NumberPlayers numberPlayers = NumberPlayers.one;

    void Start()
    {
        cam = GetComponent<Camera>();

        //inaktivera denna ifall ni vill testa med egna gubbar i er scen. dvs inte gå via menyn för att köra er bana.
        numberPlayers = (NumberPlayers)FindObjectOfType<nrPlayers>().playerCount - 1; //sätter värden på enum med int


        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");

        players[0] = player1;
        players[1] = player2;
        players[2] = player3;
        players[3] = player4;
    }

    void Update()
    {
        switch (numberPlayers)
        {
            case NumberPlayers.one:

                distance = Vector3.Distance(players[0].gameObject.transform.position, players[0].gameObject.transform.position);

                cam.fieldOfView = minFOV;


                cameraPos = new Vector3(players[0].gameObject.transform.position.x,
                    40,
                    (players[0].gameObject.transform.position.z - 15));

                transform.position = cameraPos;

                break;

            case NumberPlayers.two:

                distance = Vector3.Distance(players[0].gameObject.transform.position, players[1].gameObject.transform.position);

                averageDistance = distance / 2f;

                zoom = Mathf.InverseLerp(0f, 100f, averageDistance);
                cam.fieldOfView = Mathf.Lerp(minFOV, maxFOV, zoom * 5);

               

                cameraPos = new Vector3(((players[0].gameObject.transform.position.x+ players[1].gameObject.transform.position.x)/2),
                    40,
                    ((players[0].gameObject.transform.position.z+ players[1].gameObject.transform.position.z)/2) - 15);

                transform.position = cameraPos;

                break;

            case NumberPlayers.three:

                distance = Vector3.Distance(players[0].gameObject.transform.position, players[1].gameObject.transform.position);
                distance += Vector3.Distance(players[0].gameObject.transform.position, players[2].gameObject.transform.position);
                distance += Vector3.Distance(players[1].gameObject.transform.position, players[2].gameObject.transform.position);

                averageDistance = distance / 3f;

                zoom = Mathf.InverseLerp(0f, 100f, averageDistance);
                cam.fieldOfView = Mathf.Lerp(minFOV, maxFOV, zoom * 5);

               

                cameraPos = new Vector3((players[0].gameObject.transform.position.x + players[1].gameObject.transform.position.x+ players[2].gameObject.transform.position.x) / 3,
                    40,
                    ((players[0].gameObject.transform.position.z + players[1].gameObject.transform.position.z+ players[2].gameObject.transform.position.z) / 3) - 15);

                transform.position = cameraPos;


                break;

            case NumberPlayers.four:

                distance = Vector3.Distance(players[0].gameObject.transform.position, players[1].gameObject.transform.position);
                distance += Vector3.Distance(players[0].gameObject.transform.position, players[2].gameObject.transform.position);
                distance += Vector3.Distance(players[0].gameObject.transform.position, players[3].gameObject.transform.position);
                distance += Vector3.Distance(players[1].gameObject.transform.position, players[2].gameObject.transform.position);
                distance += Vector3.Distance(players[1].gameObject.transform.position, players[3].gameObject.transform.position);
                distance += Vector3.Distance(players[2].gameObject.transform.position, players[3].gameObject.transform.position);

                averageDistance = distance / 6f;

                zoom = Mathf.InverseLerp(0f, 100f, averageDistance);
                cam.fieldOfView = Mathf.Lerp(minFOV, maxFOV, zoom * 5);

                

                cameraPos = new Vector3((players[0].gameObject.transform.position.x + players[1].gameObject.transform.position.x+ players[2].gameObject.transform.position.x+ players[3].gameObject.transform.position.x) / 4,
                    40,
                    ((players[0].gameObject.transform.position.z + players[1].gameObject.transform.position.z+ players[2].gameObject.transform.position.z+ players[3].gameObject.transform.position.z) / 4) - 15);

                transform.position = cameraPos;

                break;



        }
        

    }
}
