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
        Loader.Load(Loader.Scene.Lobby);
        onePlayer = true;
        BomberManger.playerCountBomber = 1;
    }
    public void TwoPlayer()
    {
        twoPlayer = true;
        Loader.Load(Loader.Scene.Lobby);
        BomberManger.playerCountBomber = 1;
    }
    public void ThreePlayer()
    {
        threePlayer = true;
        Loader.Load(Loader.Scene.Lobby);
        BomberManger.playerCountBomber = 2;
    }
    public void FourPlayer()
    {
        fourPlayer = true;
        Loader.Load(Loader.Scene.Lobby);
        BomberManger.playerCountBomber = 3;
    }
}
