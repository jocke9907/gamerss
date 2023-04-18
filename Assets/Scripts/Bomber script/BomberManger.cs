using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BomberManger : MonoBehaviour
{
    public int playerCountBomber;
    public int nrOfPlayers;
    public  int bomberPoints = 1;
    public  int bombUppgrade = 0;

  
    public  bool playerCount;
    public  bool changeGame;
    PlayerController playerController;
    PlayerLevel playerLevel;
    // byt fr�n static
    public bool redusePlayers;
    public float targetTime2 = 4.0f;
    BomberScript bomberScript;
    public bool bomberPlayed;
    public bool fallinggroundPlayed;
    public bool wallClimerPlayed;
    public bool mazePlayed;
    public bool captureTheFlagPlayed;
    ////
    ///
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerLevel = FindObjectOfType<PlayerLevel>();
        //playerCountBomber--;
    }

    public void GameStart()
    {
        playerCount = false;
        //redusePlayers = false;
    }
    public void PlayerCounter()
    {
        //trd = new Thread(ThreadS);

        //Debug.Log(playerCount);
        if (playerCountBomber <= 0)
        {
            playerCount = true;

            playerLevel = FindObjectOfType<PlayerLevel>();

            //bomberScript = GetComponent<BomberScript>();

            //Loader.Load(Loader.Scene.PostLobby);
        }


    }
    void Update()
    {
        PlayerCounter();

        if (redusePlayers)
        {
            playerCountBomber--;
            redusePlayers = false;
        }

        //if (playerCountBomber == 0)
        //{
        //    ch = true;

        //    bombUppgrade = 0;
        //    playerLevel.playerDead = true;
        //    //bomberScript = GetComponent<BomberScript>();
        //    //bomberScript.Winner();
        //    targetTime2 -= Time.deltaTime;
        //}
        if(playerCount && Loader.bomberGamePlaying)
        {
            targetTime2 -= Time.deltaTime;
            //bomberScript.Winner();
        }
        
        if (targetTime2 <= 0f  )
        {
            //playerController.transform.position = new Vector3(0, 40, 0);
            Loader.bomberGamePlaying = false;
            playerCount = false;
            ////playerLevel.playerDead = true;
            bombUppgrade = 0;
            
            Loader.Load(Loader.Scene.PostLobby);
            targetTime2 = 5.0f;
            
        }

    }
    
}
