using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevel : MonoBehaviour
{
    private static bool platformSceneLoaded = false;
    private PlayerScore playerScore;

    bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        playerScore = GetComponent<PlayerScore>();
    }
    // Update is called once per frame
    void Update()
    {
        //Ground is falling
        if (Loader.PlatformGamePlaying == true && alive)
        {
            if (!platformSceneLoaded)
            {
                gameObject.transform.position = new Vector3 (0,3,0);
                Debug.Log(transform.position);
                if(gameObject.transform.position == new Vector3 (0,3,0))
                {
                    Debug.Log(transform.position);
                    platformSceneLoaded = true;
                }
            }

            if (transform.position.y < -10)
            {
                playerScore.currentScore = playerScore.currentScore + KillerBox.points;
                Debug.Log("Player x is now out and is awarded " + KillerBox.points + " points!");
                alive = false;

            }
        }
    }



}
