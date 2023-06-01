using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    //This script count every player that joins saves that int. When a player then jumps off the platform that int decreases. 
    //When it reaches 0 every player has left the platform and the game can begin.

    public bool gameStarted = false;
    int collisionCount = 0;
    [SerializeField] BoxCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Current Count"+collisionCount);
        if(gameStarted == true && Loader.PlatformGamePlaying)
        {
            Debug.Log("Game has started");
            collider.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            collisionCount++;
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
            collisionCount--;
        if (collisionCount<= 0)
        gameStarted = true;
    }

}
