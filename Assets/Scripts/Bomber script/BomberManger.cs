using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BomberManger : MonoBehaviour
{
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
        //enabler = FindObjectOfType<InputSystemEnabler>();
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
       

        //if (playerCountBomber == 0)
        //{
        //    ch = true;

        //    bombUppgrade = 0;
        //    playerLevel.playerDead = true;
        //    //bomberScript = GetComponent<BomberScript>();
        //    //bomberScript.Winner();
        //    targetTime2 -= Time.deltaTime;
        //}
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

            //ActivatePlayers();
            //playerController.transform.position = new Vector3(0, 40, 0);
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
    //private void FixedUpdate()
    //{
    //    if(targetTime2 <= 0f)
    //    {
    //        if (hasActivated)
    //        {
    //            return;
    //        }
    //        frameCounter++;
    //        if (frameCounter >= waitForFrames)
    //        {
    //            ActivatePlayers();
    //        }
    //        hasActivated = true;
    //    }
        
    //}
    //public void ActivatePlayers()
    //{
    //    PlayerManager manager = FindObjectOfType<PlayerManager>();
        

    //    Debug.Log(manager.GetPlayers());
        
    //    // PlayerController[] players = FindObjectsOfType<PlayerController>();
    //    if(!active)
    //    {
    //        foreach (PlayerController player in manager.GetPlayers())
    //        {
                
    //            //enabler.gameObject.SetActive(true);
    //            player.gameObject.SetActive(true);
    //        }
    //    }
    //    active = true;
        
        

    //}
    
    
}
