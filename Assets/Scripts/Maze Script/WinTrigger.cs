using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{

    public GameObject youWinText;
    public float delay;

    public float timer = 63f;
    public string loadScene;

    void Start()
    {
        youWinText.SetActive(false);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 )
        {
            SceneManager.LoadScene(2);
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
