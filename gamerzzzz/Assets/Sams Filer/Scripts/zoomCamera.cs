using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomCamera : MonoBehaviour
{

    //------------------------kamera zoom med mus-------------------


    //private void Update()
    //{
    //    if(Input.GetAxis("Mouse ScrollWheel") > 0)
    //    {
    //        GetComponent<Camera>().fieldOfView--;
    //    }
    //    if (Input.GetAxis("Mouse ScrollWheel") < 0)
    //    {
    //        GetComponent<Camera>().fieldOfView++;
    //    }

    //}
    //--------------------------------------------------------------


    public Transform player1;
    public Transform player2;
    public Transform player3;
    public Transform player4;

    private Transform minDisPlayer;
    private Transform maxDisPlayer;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float distance;
    Camera camera;
    public float distanceTest;

    public float minFOV = 30f;
    public float maxFOV = 60f;

    float p1Dis;
    float p2Dis;
    float p3Dis;
    float p4Dis;

    private void Start()
    {


    }


    private void LateUpdate()
    {
        //räkna ut vem av targets som är minPlayer och maxPlayer
        //-----------------------------------------
        MaxDisChecker();
        MinDisChecker();



        //-----------------------------FOW beroende på hur långt ifrån spelarna är från varandra.
        distance = Mathf.Sqrt((maxDisPlayer.position.x - minDisPlayer.position.x) * (maxDisPlayer.position.x - minDisPlayer.position.x) +
            (maxDisPlayer.position.z + 10 - minDisPlayer.position.z) * (maxDisPlayer.position.z + 10 - minDisPlayer.position.z));

        //distance = Mathf.Sqrt((player1.position.x - player2.position.x) * (player1.position.x - player2.position.x) +
        //    (player1.position.z + 10 - player2.position.z) * (player1.position.z + 10 - player2.position.z));

        if (distance * 1.25f < 35)
        {
            GetComponent<Camera>().fieldOfView = 35;
        }
        else if(distance * 1.25f > 60)
        {
            GetComponent<Camera>().fieldOfView = 60;
        }
        else
        {
            GetComponent<Camera>().fieldOfView = distance * 1.25f;
        }

 //------------kameran centrerar i mitten alla spelare 
        offset = new Vector3((player1.position.x + player2.position.x + player3.position.x + player4.position.x) / 4,
            40,
            (player1.position.z + player2.position.z + player3.position.z + player4.position.z) / 4);

        transform.position = offset;


        distanceTest = Mathf.Sqrt(Mathf.Pow(offset.x, 2) + Mathf.Pow(offset.y, 2) + Mathf.Pow(offset.z, 2));

    }






    private void MaxDisChecker()
    {
        p1Dis = player1.position.x + player1.position.z;
        p2Dis = player2.position.x + player2.position.z;
        p3Dis = player3.position.x + player3.position.z;
        p4Dis = player4.position.x + player4.position.z;

//-----------MAX------------------------------------
        if (p1Dis > p2Dis && p1Dis > p3Dis && p1Dis > p4Dis)
        {
            maxDisPlayer = player1;
        }
        else if (p2Dis > p1Dis && p2Dis > p3Dis && p1Dis > p4Dis)
        {
            maxDisPlayer = player2;
        }
        else if (p3Dis > p1Dis && p3Dis > p2Dis && p1Dis > p4Dis)
        {
            maxDisPlayer = player3;
        }
        else if (p4Dis > p1Dis && p4Dis > p2Dis && p4Dis > p3Dis)
        {
            maxDisPlayer = player4;
        }

    }
//----------MIN-----------------------------
    private void MinDisChecker()
    {
        p1Dis = player1.position.x + player1.position.z;
        p2Dis = player2.position.x + player2.position.z;
        p3Dis = player3.position.x + player3.position.z;
        p4Dis = player4.position.x + player4.position.z;

        if (p1Dis < p2Dis && p1Dis < p3Dis && p1Dis < p4Dis)
        {
            minDisPlayer = player1;
        }
        else if (p2Dis < p1Dis && p2Dis < p3Dis && p2Dis < p4Dis)
        {
            minDisPlayer = player2;
        }
        else if (p3Dis < p1Dis && p3Dis < p2Dis && p3Dis < p4Dis)
        {
            minDisPlayer = player3;
        }
        else if (p4Dis < p1Dis && p4Dis < p2Dis && p4Dis < p3Dis)
        {
            minDisPlayer = player4;
        }
    }

}
