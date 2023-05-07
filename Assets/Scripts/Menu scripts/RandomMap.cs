using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
    BomberManger bomberManger;
    float targetTime3 = 11f;
    bool giveScore = true;
    bool changeMap = false;
    bool mapSelected;
    public int randMap;
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

        if (targetTime3 < 10)
        {
            ChangeMaps();
        }
        if (targetTime3 <= 0)
        {
            changeMap = true;
        }
    }
    void ChangeMaps()
    {


        Loader.TheMazePlaying = false;
        if (mapSelected == false)
        {
            randMap = Random.Range(1, 6);
        }

        //bomberManger.captureTheFlagPlayed = true;

        // �ndra denna f�r att byta map
        //randMap = 4;
        //
        if (!bomberManger.fallinggroundPlayed && randMap == 1)
        {
            mapSelected = true;
            if (changeMap)
            {
                bomberManger.redusePlayers = false;
                bomberManger.fallinggroundPlayed = true;
                Loader.PlatformGamePlaying = true;
                Loader.Load(Loader.Scene.ViggesScene);
            }
        }
        else if (!bomberManger.bomberPlayed && randMap == 2)
        {
            mapSelected = true;
            if (changeMap)
            {
                bomberManger.redusePlayers = false;
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
        }
        else if (!bomberManger.captureTheFlagPlayed && randMap == 6)
        {
            mapSelected = true;
            if (changeMap)
            {
                bomberManger.captureTheFlagPlayed = true;
                Loader.Load(Loader.Scene.CaptureTheFlag);
            }
        }
        else if (!bomberManger.mazePlayed && randMap == 3)
        {
            mapSelected = true;
            if (changeMap)
            {
                bomberManger.mazePlayed = true;
                Loader.TheMazePlaying = true;
                Loader.wallClimberPlaying = false;
                Loader.Load(Loader.Scene.TheMaze);
            }
        }
        else if (!bomberManger.wallClimerPlayed && randMap == 4)
        {
            mapSelected = true;
            if (changeMap)
            {
                bomberManger.wallClimerPlayed = true;
                Loader.wallClimberPlaying = true;
                //Loader.TheMazePlaying = false;
                Loader.Load(Loader.Scene.SamScen);
            }

        }
        else if (!bomberManger.lavaGroundPlayed && randMap == 5)
        {
            mapSelected = true;
            if (changeMap)
            {
                bomberManger.redusePlayers = false;
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
        }
        else
        {
            if (mapSelected == false)
            {
                randMap = Random.Range(1, 6);
            }
        }
    }
}
