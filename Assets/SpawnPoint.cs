using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool gameStarted = false;
    int collisionCount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Current Count"+collisionCount);
        if(gameStarted == true)
        Debug.Log("Game has started");
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
