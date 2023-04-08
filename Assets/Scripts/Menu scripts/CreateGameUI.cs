using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameUI : MonoBehaviour
{

    public static bool onePlayer;
    public static bool twoPlayer;
    public static bool threePlayer;
    public static bool fourPlayer;

    public void ChangeSceneBomber()
    {      
        Loader.Load(Loader.Scene.BomberGame);
        Loader.bomberGamePlaying = true;
    }

    public void ChangeSceneRandom() 
    {
        Loader.Load(Loader.Scene.ViggesScene);
    }

    public void ChangeLobbyScene()
    {
        Loader.Load(Loader.Scene.Lobby);
    }

    public void OnePlayer()
    {
        
        onePlayer = true;
        BomberManger.playerCountBomber = 1;
        KillerBox.playercounter = 2;
        Loader.Load(Loader.Scene.Lobby);
    }
    public void TwoPlayer()
    {
        twoPlayer = true;
        
        BomberManger.playerCountBomber = 1;
        KillerBox.playercounter = 4;
        Loader.Load(Loader.Scene.Lobby);
    }
    public void ThreePlayer()
    {
        threePlayer = true;
        
        BomberManger.playerCountBomber = 2;
        KillerBox.playercounter = 6;
        Loader.Load(Loader.Scene.Lobby);
    }
    public void FourPlayer()
    {
        fourPlayer = true;
       
        BomberManger.playerCountBomber = 3;
        KillerBox.playercounter = 8;
        Loader.Load(Loader.Scene.Lobby);
    }
}
