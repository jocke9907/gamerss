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
    PlayerController playerController;
    PlayerLevel playerLevel;
    // byt från static

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerLevel = GetComponent<PlayerLevel>();
    }
    public void PlayerCounter()
    {
        //trd = new Thread(ThreadS);

        Debug.Log(changeGame);
        if (playerCountBomber == 0)
        {
            //playerController.transform.position =  new Vector3(0, 40, 0);
            bombUppgrade = 0;
            playerLevel.playerDead = true;
            ch = true;

        }
        

    }

}
