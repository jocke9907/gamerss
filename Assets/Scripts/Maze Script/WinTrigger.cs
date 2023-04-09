using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    public float timer = 63f;
    public string loadScene;
    public static int points = 0;

    public bool isFinnished = false;

    PlayerScore playerScore;

    GameObject firstPlayer = null;

    void Start()
    {
       // youWinText.SetActive(false);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 /*|| isFinnished == true*/)
        {
            SceneManager.LoadScene(5);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(firstPlayer == null)
            {
                firstPlayer = gameObject;
                points = 50;
            }
            else if(other.gameObject == firstPlayer)
            {
                return;
            }
            else
            {
                points = 30;
            }
            other.GetComponent<PlayerScore>();
            playerScore.currentScore += 50;
            other.GetComponent<CharacterMovement>().enabled = false;
           // isFinnished=true;
        }
    }
}
