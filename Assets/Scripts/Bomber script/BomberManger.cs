using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public static class BomberManger 
{
    public static int playerCountBomber;
    public static int bomberPoints = 1;
    public static int bombUppgrade = 0;

  
    public static bool ch;
    public static bool changeGame;
    
   

    public static void PlayerCounter()
    {
        //trd = new Thread(ThreadS);

        Debug.Log(changeGame);
        if (playerCountBomber == 0)
        {
            bombUppgrade = 0;
            ch = true;

        }
        

    }

}
