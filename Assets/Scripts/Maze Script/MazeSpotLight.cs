using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpotLight : MonoBehaviour
{
    public Light spotlightPrefab; // The prefab for the spotlight
    public int numPlayers = 2;
    public float spacing = 1.0f; // The spacing between spotlights

    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");


        // If there are fewer players than expected, disable excess spotlights
        int numSpotlights = Mathf.Min(numPlayers, players.Length);
        for (int i = numSpotlights; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        // Create a spotlight for each player
        for (int i = 0; i < numSpotlights; i++)
        {
            Vector3 playerPos = players[i].transform.position;

            // Create a new spotlight and set its position and rotation
            Light newSpotlight = Instantiate(spotlightPrefab, transform);
            newSpotlight.transform.position = new Vector3(playerPos.x, transform.position.y, playerPos.z);
            newSpotlight.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 0.0f));

            // Offset the spotlight's position based on the number of players and spacing
            float offset = (numSpotlights - 1) * spacing / 2.0f;
            newSpotlight.transform.position += new Vector3(i * spacing - offset, 0.0f, 0.0f);
        }
    }
}
