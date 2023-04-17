using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
    BomberManger bomberManger;
    float targetTime3 = 5f;
    private void Awake()
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
        bomberManger = FindObjectOfType<BomberManger>();
        int randMap = Random.Range(1, 3);
        randMap = 3;
        if (randMap == 1)
        {
            Loader.PlatformGamePlaying = true;
            Loader.Load(Loader.Scene.ViggesScene);
        }
        else if (randMap == 2)
        {
            bomberManger.GameStart();
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
        else if (randMap == 4)
        {
            Loader.Load(Loader.Scene.CaptureTheFlag);
        }
        else if (randMap == 3)
        {
            Loader.TheMazePlaying = true;
            Loader.wallClimberPlaying = false;
            Loader.Load(Loader.Scene.TheMaze);
        }
        else if (randMap == 5)
        {
            Loader.wallClimberPlaying = true;
            Loader.TheMazePlaying = false;
            Loader.Load(Loader.Scene.SamScen);
        }
    }
}
