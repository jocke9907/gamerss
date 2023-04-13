using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BomberManger : MonoBehaviour
{
    public int playerCountBomber;
    public  int bomberPoints = 1;
    public  int bombUppgrade = 0;

  
    public  bool ch;
    public  bool changeGame;
    
   // byt från static

    public void PlayerCounter()
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
