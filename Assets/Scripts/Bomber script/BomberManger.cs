using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BomberManger : MonoBehaviour
{
    // Handels bools and game play for bomber and Ground is Lava

    public int playerCountBomber;
    public int nrOfPlayers;
    public int bomberPoints ;
    public  int bombUppgrade ;
    public int giveScore ;
  
    public  bool playerCount;
    public  bool changeGame;
    PlayerController playerController;
    //InputSystemEnabler enabler;
    PlayerLevel playerLevel;
    // byt från static
    public bool redusePlayers = false;
    public float targetTime2 = 4.0f;
    BomberScript bomberScript;
    public bool bomberPlayed;
    public bool fallinggroundPlayed;
    public bool wallClimerPlayed;
    public bool mazePlayed;
    public bool captureTheFlagPlayed;
    public bool lavaGroundPlayed;
    public bool spinningWheelPlayed;
    public int gamesPlayed = 0;

    bool given = false;
    public float timer = 202f;
    ////
    int waitForFrames = 2;
    int frameCounter;
    bool hasActivated = false;
    bool active = false;
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerLevel = FindObjectOfType<PlayerLevel>();
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
        }
        


    }
    void Update()
    {
        if(Loader.bomberGamePlaying)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                playerCountBomber -= 4;
            }
        }
       

        PlayerCounter();
       
        
        if (redusePlayers)
        {
            playerCountBomber--;
            redusePlayers = false;
            redusePlayers = false;
        }
       

        if (playerCount && Loader.bomberGamePlaying)
        {
            targetTime2 -= Time.deltaTime;
           
            bomberPlayed = true;
            //bomberScript.Winner();
        }
        if (playerCount && Loader.LavaGroundPlaying)
        {
            targetTime2 -= Time.deltaTime;

            lavaGroundPlayed = true;
            
        }
        if (targetTime2 <= 3f)
        {
            //ActivatePlayers();
        }

        if (targetTime2 <= 0f  )
        {
            Loader.bomberGamePlaying = false;
            Loader.LavaGroundPlaying = false;
            playerCount = false;
            ////playerLevel.playerDead = true;
            bombUppgrade = 0;

            //if (hasActivated)
            //{
            //    return;
            //}
            frameCounter++;
            frameCounter++;
            frameCounter++;
            Debug.Log(frameCounter);
            if (frameCounter >= waitForFrames)
            {
                Loader.Load(Loader.Scene.PostLobby);
            }
            hasActivated = true;
            

           
           
            targetTime2 = 5.0f;
            
        }

    }
    
    
}
