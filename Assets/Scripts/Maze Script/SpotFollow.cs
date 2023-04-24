using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject spotlightPrefab;
    public float spotlightOffset = 2f;

    private List<GameObject> players = new List<GameObject>();
    private List<GameObject> spotlights = new List<GameObject>();

    private void Start()
    {
        // Get all players in the scene
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");

        // Instantiate a spotlight for each player
        foreach (GameObject player in playerObjects)
        {
            GameObject spotlight = Instantiate(spotlightPrefab, player.transform.position + Vector3.up * spotlightOffset, Quaternion.identity);
            spotlight.transform.parent = player.transform;
            spotlights.Add(spotlight);
            players.Add(player);
        }
    }

    private void Update()
    {
        // Update the position of each spotlight to follow its corresponding player
        for (int i = 0; i < players.Count; i++)
        {
            spotlights[i].transform.position = players[i].transform.position + Vector3.up * spotlightOffset;
        }
    }
}
