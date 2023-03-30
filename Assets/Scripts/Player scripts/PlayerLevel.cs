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
        //Ground is falling gamemode
        if (Loader.PlatformGamePlaying == true && !platformSceneLoaded)
        {
            gameObject.transform.position = PlatformSpawnPoint.platformSpawnPoint;
            platformSceneLoaded = true;
        }
        if (Loader.PlatformGamePlaying == true)
        {

            if (alive && transform.position.y < -10)
            {
                playerScore.currentScore = playerScore.currentScore + KillerBox.points;
                Debug.Log("Player x is now out and is awarded " + KillerBox.points + " points!");
                alive = false;

            }
        }
    }
}
