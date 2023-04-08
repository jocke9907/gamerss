using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public static class BomberManger 
{
    public static int playerCountBomber;
    public static int bomberPoints = 1;
    //private static Thread trd;
    public static bool ch;
    public static bool changeGame;
    
   

    public static void PlayerCounter()
    {
        //trd = new Thread(ThreadS);

        Debug.Log(changeGame);
        if (playerCountBomber == 0)
        {
            
            ch = true;

        }
        

    }

    //private static void ThreadS()
    //{
    //    Thread.Sleep(2000);
    //}

    //playerScore.currentScore = playerScore.currentScore
}
