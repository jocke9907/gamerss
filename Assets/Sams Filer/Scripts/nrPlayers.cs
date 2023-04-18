using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nrPlayers : MonoBehaviour
{
    public enum NumberOfPlayers { one, two, three, four }
    public NumberOfPlayers numberPlayers;


    scoreSystem1 system1;
    

    public int playerCount;

    public void UpdatePlayerCount()
    {
        system1 = FindObjectOfType<scoreSystem1>();
  
        numberPlayers = (NumberOfPlayers)playerCount - 1;
  
    }
}
