using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevel : MonoBehaviour
{
    bool playerSpawned = false;
    PlayerScore playerScore;
    PlayerController playerController;

    public bool playerDead;
    public bool scoreGiven;
    BomberManger bomberManger;
    bool alive = true;
    // Start is called before the first frame update
    private void Awake()
    {
        bomberManger = FindObjectOfType<BomberManger>();
        playerController = FindObjectOfType<PlayerController>();
    }
    void Start()
    {
        playerScore = GetComponent<PlayerScore>();
    }
    // Update is called once per frame
    void Update()
    {

        //Ground is falling  && alive
        OnBomber();

        if (Loader.TheMazePlaying == true )
        {
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }
    private void FixedUpdate()
    {
        OnGroundIsFalling();
        onCaptureTheFlag();
    }

    private void OnGroundIsFalling()
    {
        if (Loader.PlatformGamePlaying == true)
        {
            if (alive)
            {

                if (!playerSpawned)
                {
                    playerSpawned = true;
                    transform.position = new Vector3(0, 2, 0);

                }
                if (transform.position.y < -40)
                {
                    playerController.totalScore = playerController.totalScore + KillerBox.points;
                    Debug.Log("Player x is now out and is awarded " + KillerBox.points + " points!");
                    KillerBox.points++;
                    KillerBox.playercounter--;
                    alive = false;

                }
            }

            if (!alive)
            {
                //transform.position = new Vector3(0, 4, 0);
                //alive = true;
            }

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        //Ground is falling
        if (Loader.PlatformGamePlaying == true && other.CompareTag("Killbox"))
        {
            playerScore.currentScore = playerScore.currentScore + KillerBox.points;
            Debug.Log("Player x is now out and is awarded " + KillerBox.points + " points!");
            alive = false;
        }
        if(Loader.captureTheFlagPlaying == true && other.CompareTag("Killbox"))
        {
            alive = false;
        }


    }

    private void OnBomber()
    {
        //if (transform.position.y > 25 && scoreGiven == false)
        //{
        //    playerDead = true;
        //}
        if (playerDead && scoreGiven == false)
        {
            Debug.Log("score given");
            playerScore.currentScore = playerScore.currentScore + bomberManger.bomberPoints;
            playerController.totalScore += bomberManger.bomberPoints;
            scoreGiven = true;
        }
    }
    public void onCaptureTheFlag()
    {
        if(!alive && Loader.captureTheFlagPlaying)
        {
            transform.position=new Vector3(-8, 12, -23);
            alive = true;
        }
    }
}


