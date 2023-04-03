using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevel : MonoBehaviour
{
    bool playerSpawned = false;
    private PlayerScore playerScore;
    Transform transform;

    bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        playerScore= GetComponent<PlayerScore>();
        transform = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        //Ground is falling
        if(Loader.PlatformGamePlaying == true && alive)
        {
            if (!playerSpawned)
            {
                playerSpawned = true;
                transform.position = new Vector3(0,2,0);
                
            }
            if (transform.position.y < -10)
            {
                playerScore.currentScore = playerScore.currentScore + KillerBox.points;
                Debug.Log("Player x is now out and is awarded "+ KillerBox.points+ " points!");
                    alive = false;  
                
            }
        }

        if (Loader.TheMazePlaying == true && alive)
        {
          gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
    }


}
