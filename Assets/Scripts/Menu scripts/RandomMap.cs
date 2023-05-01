using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
    BomberManger bomberManger;
    float targetTime3 = 5f;
    bool giveScore = true;
    private void Awake()
    {
        bomberManger = FindObjectOfType<BomberManger>();
        PlayerManager manager = FindObjectOfType<PlayerManager>();
        // PlayerController[] players = FindObjectsOfType<PlayerController>();
        foreach (PlayerController player in manager.GetPlayers())
        {
            player.veryDead = false;
            //player.gameObject.SetActive(true);
        }
        giveScore = true;
        

    }
    private void Start()
    {
        
    }
    void Update()
    {

        


        targetTime3 -= Time.deltaTime;

        if (targetTime3 < 0)
        {
            ChangeMaps();
        }
    }
    void ChangeMaps()
    {
       
        
        Loader.TheMazePlaying = false;

        int randMap = Random.Range(1, 6);
        //bomberManger.captureTheFlagPlayed = true;

        // ändra denna för att byta map
        randMap = 5;
        //
        if (!bomberManger.fallinggroundPlayed && randMap == 1)
        {
            bomberManger.fallinggroundPlayed = true;
            Loader.PlatformGamePlaying = true;
            Loader.Load(Loader.Scene.ViggesScene);

        }
        else if (!bomberManger.bomberPlayed && randMap == 2)
        {
            bomberManger.bomberPlayed = true;
            bomberManger.GameStart();
            bomberManger.bomberPoints = 4;
            if (CreateGameUI.onePlayer == true)
            {
                bomberManger.playerCountBomber = 1;
            }
            if (CreateGameUI.twoPlayer == true)
            {
                bomberManger.playerCountBomber = 1;
            }
            if (CreateGameUI.threePlayer == true)
            {
                bomberManger.playerCountBomber = 2;
            }
            if (CreateGameUI.fourPlayer == true)
            {
                bomberManger.playerCountBomber = 3;
            }
            Loader.bomberGamePlaying = true;
            Loader.Load(Loader.Scene.BomberGame);
        }
        else if (!bomberManger.captureTheFlagPlayed && randMap == 6)
        {
            bomberManger.captureTheFlagPlayed = true;
            Loader.Load(Loader.Scene.CaptureTheFlag);
        }
        else if (!bomberManger.mazePlayed && randMap == 3)
        {
            bomberManger.mazePlayed = true;
            Loader.TheMazePlaying = true;
            Loader.wallClimberPlaying = false;
            Loader.Load(Loader.Scene.TheMaze);
        }
        else if (!bomberManger.wallClimerPlayed && randMap == 4)
        {
            bomberManger.wallClimerPlayed = true;
            Loader.wallClimberPlaying = true;
            //Loader.TheMazePlaying = false;
            Loader.Load(Loader.Scene.SamScen);
        }
        else if (!bomberManger.lavaGroundPlayed && randMap == 5)
        {
            bomberManger.lavaGroundPlayed = true;
            bomberManger.GameStart();
            bomberManger.bomberPoints = 4;
            if (CreateGameUI.onePlayer == true)
            {
                bomberManger.playerCountBomber = 1;
            }
            if (CreateGameUI.twoPlayer == true)
            {
                bomberManger.playerCountBomber = 1;
            }
            if (CreateGameUI.threePlayer == true)
            {
                bomberManger.playerCountBomber = 2;
            }
            if (CreateGameUI.fourPlayer == true)
            {
                bomberManger.playerCountBomber = 3;
            }
            Loader.LavaGroundPlaying = true;
            Loader.Load(Loader.Scene.LavaGround);
        }
        else
        {
            randMap = Random.Range(1, 6);
        }
    }
}
