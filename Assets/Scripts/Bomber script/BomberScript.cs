using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BomberScript : MonoBehaviour
{
    public static int playerLeft ;
   
    public TextMeshProUGUI players;
    public TextMeshProUGUI winner;
    PlayerScore playerScore;
    PlayerController playerController;
    private Thread trd;
    public static float targetTime1 = 4.0f;


    public void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        //playerScore = GetComponent<PlayerScore>();
        //trd = new Thread(ThreadS);
    }

    // Update is called once per frame
    void Update()
    {
        
        //scoreValue = BomberManger.bomberPoints;
        playerLeft = BomberManger.playerCountBomber;
        players.text = "Players left " + (playerLeft +1);
        //score.text = "score:" + playerScore.currentScore;
        if(BomberManger.ch == true )
        {
            
            Winner();
            targetTime1 -= Time.deltaTime;
            //trd.Start();




        }
        
        if (targetTime1 >= -0.2f && targetTime1 <= 0.0f)
        {

            Loader.bomberGamePlaying = false;

            BomberScript.targetTime1 = 5.0f;
            BomberManger.ch = false;
            Loader.Load(Loader.Scene.Lobby);

        }
    }

    private void Winner()
    {
        winner.text = "The winner is ---- \nSecond place ----";
        BomberManger.changeGame = true;


    }

   
    //private static void ThreadS()
    //{
    //    //Thread.Sleep(200);
    //    changeGame = true;
    //}
}
