using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nrPlayers : MonoBehaviour
{

    //----------SCRIPT WRITTEN BY SAM---------------

    // this script checks to see how many players have been selected in the meny script
    // and declares that in playerCount.

    // This variable is then used in all my other scripts to know how many players are in game,
    // so they can choose the correct enum states while in game.

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
