using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMan : MonoBehaviour
{



    public GameObject[] players;



    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;


    // Start is called before the first frame update
    //public Transform player1;
    //public Transform player2;
    //public Transform player3;
    //public Transform player4;


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
