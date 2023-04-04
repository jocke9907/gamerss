using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{

   // GameObject player = GameObject.Find("Player");
   // PlayerController playerController = player.GetComponent<PlayerController>();

   // public GameObject youWinText;
    //public float delay;

    public float timer = 63f;
    public string loadScene;
    public static int points = 0;

    public bool isFinnished = false;

    PlayerScore playerScore;

    void Start()
    {
       // youWinText.SetActive(false);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 || isFinnished == true)
        {
            SceneManager.LoadScene(5);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScore>();
            playerScore.currentScore += 50;
            isFinnished=true;
        }
    }


    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        youWinText.SetActive(true);
    //        StartCoroutine(Countdown());
    //    }
    //    else if (timer == 0f)
    //    {
    //        Debug.Log("You Lose");
    //    }
    //}

    //IEnumerator Countdown()
    //{
    //    yield return new WaitForSeconds(delay);
    //    SceneManager.LoadScene(2);
    //}
}
