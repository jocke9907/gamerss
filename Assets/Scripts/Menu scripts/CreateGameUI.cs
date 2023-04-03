using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameUI : MonoBehaviour
{
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
        BomberManger.playerCountBomber = 1;
    }
    public void TwoPlayer()
    {
        Loader.Load(Loader.Scene.Lobby);
        BomberManger.playerCountBomber = 2;
    }
    public void ThreePlayer()
    {
        Loader.Load(Loader.Scene.Lobby);
        BomberManger.playerCountBomber = 3;
    }
    public void FourPlayer()
    {
        Loader.Load(Loader.Scene.Lobby);
        BomberManger.playerCountBomber = 4;
    }
}
