using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScoreManager : MonoBehaviour
{
    PlayerInputManager inputManager;
    List<GameObject> playerList = new List<GameObject>();
    //Adds every player to a list to easier give them score later on.
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        inputManager= GetComponent<PlayerInputManager>();
        foreach(Transform child in transform)
        {
            if(child.gameObject.tag == "Player")
            {
                playerList.Add(child.gameObject);
            }
        }
        Debug.Log(playerList.Count);
    }
}
