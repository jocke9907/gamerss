using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    List<PlayerController> controls = new List<PlayerController>();


    public List<PlayerController> GetPlayers()
    {
        //controls = new List<PlayerController>();
        //controlls { get; private set; }
        return controls;
    }
    public void AddToList(PlayerController newController)
    {
        controls.Add(newController);
    }
    

}
