using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer = 10f;
    Flag flag;
    void Update()
    {
        timer-=Time.deltaTime;
        if(timer <= 0)
        {
            flag.isFlagPickedUp = false;
            Loader.captureTheFlagPlaying = false;
            SceneManager.LoadScene(7);
           

        }
    }
}
