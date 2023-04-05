using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public static class BomberManger 
{
    public static int playerCountBomber;
    public static int bomberPoints = 1;
    private static Thread trd;


    public static void PlayerCounter()
    {
        trd = new Thread(ThreadS);

        Debug.Log(playerCountBomber);
        if (playerCountBomber == 0)
        {
            trd.Start();
            Thread.Sleep(2000);
            Debug.Log("ChangeToLobby");
            Loader.bomberGamePlaying = false;
            Loader.Load(Loader.Scene.Lobby);
        }
    }

    private static void ThreadS()
    {
        Thread.Sleep(2000);
    }

    //playerScore.currentScore = playerScore.currentScore
}
