using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelection : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject outOfSite;
    public enum NumberPlayers { one, two, three, four }
    public NumberPlayers numberPlayers = NumberPlayers.two;

    void Start()
    {
        numberPlayers = (NumberPlayers)FindObjectOfType<nrPlayers>().playerCount - 1;
    }

    public void Update()
    {
        switch (numberPlayers)
        {
            case NumberPlayers.two:

                player1.transform.position = new Vector3(7, 4, 12);
                player2.transform.position = new Vector3(13, 4, 12);
                player3.transform.position = outOfSite.transform.position;
                player4.transform.position = outOfSite.transform.position;

                break;

            case NumberPlayers.three:

                player1.transform.position = new Vector3(1, 4, 12);
                player2.transform.position = new Vector3(10, 4, 12);
                player3.transform.position = new Vector3(19, 4, 12);
                player4.transform.position = outOfSite.transform.position;

                break;

            case NumberPlayers.four:

                player1.transform.position = new Vector3(1, 4, 12);
                player2.transform.position = new Vector3(7, 4, 12);
                player3.transform.position = new Vector3(13, 4, 12);
                player4.transform.position = new Vector3(19, 4, 12);

                break;
        }
    }
   
  

    // Update is called once per frame

}
