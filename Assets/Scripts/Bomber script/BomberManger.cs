using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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
    public bool redusePlayers;
    public float targetTime2 = 4.0f;
    BomberScript bomberScript;

    ////
    ///
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerLevel = FindObjectOfType<PlayerLevel>();
    }
    public void PlayerCounter()
    {
        //trd = new Thread(ThreadS);

        Debug.Log(ch);
        if (playerCountBomber == 0)
        {
            ch = true;

            playerLevel = FindObjectOfType<PlayerLevel>();

            //bomberScript = GetComponent<BomberScript>();

            //Loader.Load(Loader.Scene.PostLobby);
        }


    }
    void Update()
    {

        if (redusePlayers)
        {
            playerCountBomber--;
            redusePlayers = false;
        }

        //if (playerCountBomber == 0)
        //{
        //    ch = true;

        //    bombUppgrade = 0;
        //    playerLevel.playerDead = true;
        //    //bomberScript = GetComponent<BomberScript>();
        //    //bomberScript.Winner();
        //    targetTime2 -= Time.deltaTime;
        //}
        if(ch)
        {
            targetTime2 -= Time.deltaTime;
            //bomberScript.Winner();
        }
        
        if (targetTime2 <= 0.0f)
        {
            //playerController.transform.position = new Vector3(0, 40, 0);
            Loader.bomberGamePlaying = false;
            ch = false;
            playerLevel.playerDead = true;
            bombUppgrade = 0;
            
            Loader.Load(Loader.Scene.PostLobby);
            targetTime2 = 5.0f;
            
        }

    }
    
}
