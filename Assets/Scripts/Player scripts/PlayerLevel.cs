using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevel : MonoBehaviour
{
    bool playerSpawned = false;
    private PlayerScore playerScore;

    public bool playerDead;
    public bool scoreGiven;
    BomberManger bomberManger;
    bool alive = true;
    // Start is called before the first frame update
    private void Awake()
    {
        bomberManger = FindObjectOfType<BomberManger>();
    }
    void Start()
    {
        playerScore = GetComponent<PlayerScore>();
    }
    // Update is called once per frame
    void Update()
    {

        //Ground is falling
        OnGroundIsFalling();
        OnBomber();

        if (Loader.TheMazePlaying == true && alive)
        {
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }

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
                //if (transform.position.y < -20)
                //{
                //    playerScore.currentScore = playerScore.currentScore + KillerBox.points;
                //    Debug.Log("Player x is now out and is awarded " + KillerBox.points + " points!");
                //    alive = false;
                //}
            }

            if (!alive)
            {
                transform.position = new Vector3(0, 4, 0);
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


    }

    private void OnBomber()
    {
        if (transform.position.y > 25 && scoreGiven == false)
        {
            playerDead = true;
        }
        if (playerDead && scoreGiven == false)
        {
            playerScore.currentScore = playerScore.currentScore + bomberManger.bomberPoints;
            scoreGiven = true;
        }
    }
}


