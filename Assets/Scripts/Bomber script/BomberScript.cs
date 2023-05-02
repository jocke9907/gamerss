using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BomberScript : MonoBehaviour
{
    public int playerLeft ;
   
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
        bomberManger.GetComponent<BomberManger>();
        //scoreValue = BomberManger.bomberPoints;
       
        //score.text = "score:" + playerScore.currentScore;
        //if (bomberManger.ch == true )
        //{
        //    Debug.Log("now");
        //    Winner();
        //    targetTime1 -= Time.deltaTime;
        //}
        
        playerLeft = bomberManger.playerCountBomber;
        players.text = "Players left " + (playerLeft + 1);

        //if (targetTime1 <= 0.0f)
        //{
        //    playerController.transform.position = new Vector3(0, 40, 0);
        //    Loader.bomberGamePlaying = false;            
        //    bomberManger.ch = false;
        //    Loader.Load(Loader.Scene.PostLobby);
        //    targetTime1 = 5.0f;

        //}
    }

    public void Winner()
    {
        winner.text = "The winner is ---- \nSecond place ----";
        bomberManger.changeGame = true;
    }   
}
