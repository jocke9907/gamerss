using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BomberManger 
{
   public static int playerCountBomber;
   public static void PlayerCounter()
   {
        Debug.Log(playerCountBomber);
        if (playerCountBomber == 0)
        {
            Debug.Log("ChangeToMenu");
            Loader.bomberGamePlaying = false;
            Loader.Load(Loader.Scene.Lobby);
        }
   }
        

}
