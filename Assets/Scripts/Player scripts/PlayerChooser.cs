using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerChooser : MonoBehaviour
{

    PlayerInputManager playerInputManager;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject playerPrefab2;

    private void Start()
    {
        playerInputManager= GetComponent<PlayerInputManager>(); 
    }
    void OnPlayerJoined(PlayerInput input)
    {
        if (player1 == null) 
        { 
            player1 = input.gameObject;
            playerInputManager.playerPrefab = playerPrefab2;
        }
        else if (player2 == null)
        {
            player2 = input.gameObject;
        }
    }
    // Start is called before the first frame update
   
}
