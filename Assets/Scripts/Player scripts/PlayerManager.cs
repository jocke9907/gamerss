using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;

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

    // new

    //public int maxPlayers = 4; // The maximum number of players that can connect
    //private int connectedPlayers = 0; // The number of players currently connected

    //private InputSystemUIInputModule inputModule;

    //private void Awake()
    //{
    //    inputModule = GetComponent<InputSystemUIInputModule>();
    //}

    //private void OnEnable()
    //{
    //    inputModule.enabled = true;
    //}

    //private void OnDisable()
    //{
    //    inputModule.enabled = false;
    //}

    //// Called by a button or other UI element to connect a new player
    //public void ConnectPlayer()
    //{
    //    if (connectedPlayers < maxPlayers)
    //    {
    //        //InputSystem.EnableDevice<Gamepad>(connectedPlayers);
    //        InputSystem.EnableDevice(Gamepad.all[connectedPlayers]);

    //        connectedPlayers++;
    //    }
    //    else
    //    {
    //        Debug.Log("Maximum number of players already connected.");
    //    }
    //}

    //// Called by a button or other UI element to disconnect a player
    //public void DisconnectPlayer()
    //{
    //    if (connectedPlayers > 0)
    //    {
    //        connectedPlayers--;
    //        InputSystem.DisableDevice(Gamepad.all[connectedPlayers]);
    //    }
    //    else
    //    {
    //        Debug.Log("No players connected.");
    //    }
    //}

}
