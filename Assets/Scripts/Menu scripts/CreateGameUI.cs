using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameUI : MonoBehaviour
{

    public static bool onePlayer;
    public static bool twoPlayer;
    public static bool threePlayer;
    public static bool fourPlayer;
    BomberManger bomberManger;
    nrPlayers _nrPlayers;


    
    public void Awake()
    {
        bomberManger = FindObjectOfType<BomberManger>();
        _nrPlayers= FindObjectOfType<nrPlayers>(); //Sam
    }
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
        
        _nrPlayers.playerCount = 1; //Sam
        _nrPlayers.UpdatePlayerCount();


        onePlayer = true;
        
        bomberManger.playerCountBomber = 1;
       // BomberManger.playerCountBomber = 1;
        KillerBox.playercounter = 2;
        Loader.Load(Loader.Scene.Lobby);
        

    }
    public void TwoPlayer()
    {
        _nrPlayers.playerCount = 2; //Sam
        _nrPlayers.UpdatePlayerCount();

        twoPlayer = true;

        bomberManger.playerCountBomber += 1;
        KillerBox.playercounter = 4;
        Loader.Load(Loader.Scene.Lobby);
    }
    public void ThreePlayer()
    {

        _nrPlayers.playerCount = 3; //Sam
        _nrPlayers.UpdatePlayerCount();
        threePlayer = true;

        bomberManger.playerCountBomber = 2;
        KillerBox.playercounter = 6;
        Loader.Load(Loader.Scene.Lobby);
    }
    public void FourPlayer()
    {
        _nrPlayers.playerCount = 4; //Sam
        _nrPlayers.UpdatePlayerCount();
        fourPlayer = true;

        bomberManger.playerCountBomber = 3;
        KillerBox.playercounter = 8;
        Loader.Load(Loader.Scene.Lobby);
    }
}
