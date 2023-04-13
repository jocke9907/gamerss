using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BomberScript : MonoBehaviour
{
    public  int playerLeft ;
   
    public TextMeshProUGUI players;
    public TextMeshProUGUI winner;
    PlayerScore playerScore;
    PlayerController playerController;
    private Thread trd;
    public  float targetTime1 = 4.0f;

    BomberManger bomberManger;
    public void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();       
        bomberManger = FindObjectOfType<BomberManger>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //scoreValue = BomberManger.bomberPoints;
        playerLeft = bomberManger.playerCountBomber;
        players.text = "Players left " + (playerLeft +1);
        //score.text = "score:" + playerScore.currentScore;
        if (bomberManger.ch == true )
        {
            
            Winner();
            targetTime1 -= Time.deltaTime;
        }
        
        if (targetTime1 >= -0.2f && targetTime1 <= 0.0f)
        {

            Loader.bomberGamePlaying = false;

            targetTime1 = 5.0f;
            bomberManger.ch = false;
            Loader.Load(Loader.Scene.Lobby);

        }
    }

    private void Winner()
    {
        winner.text = "The winner is ---- \nSecond place ----";
        bomberManger.changeGame = true;


    }

   
}
