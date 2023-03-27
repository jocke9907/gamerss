using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BomberManger 
{
   public static int playerCountBomber =1;
   public static void PlayerCounter()
   {
        if (playerCountBomber == 0)
        {
            Debug.Log("ChangeToMenu");
            Loader.bomberGamePlaying = false;
            Loader.Load(Loader.Scene.Menu);
        }
   }
        

}
