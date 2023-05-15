using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using System.Text;

public class Flag : MonoBehaviour
{
    public GameObject flagRespawnPoint;
    public float flagRespawnTime = 5f;
    private Vector3 flagOriginalPosition;
    private float flagDropTime;
    private GameObject playerWithFlag;
    public bool isFlagPickedUp;
    Dictionary<PlayerController, int> flagsCount = new Dictionary<PlayerController, int>();
    AudioSource audio;
    public TextMeshProUGUI flagsCountText;
    //public GameObject[] players;


    //GameObject player1;
    //GameObject player2;
    //GameObject player3;
    //GameObject player4;



    void Start()
    {
        int flagscore=flagsCount.Count;
        audio = GetComponent<AudioSource>();
        flagOriginalPosition = transform.position;
        //flagsCountText.text = "Blue" + players[0] +flagscore;
       
        //player1 = GameObject.Find("Player1");
        //player2 = GameObject.Find("Player2");
        //player3 = GameObject.Find("Player3");
        //player4 = GameObject.Find("Player4");

        //players[0] = player1;
        //players[1] = player2;
        //players[2] = player3;
        //players[3] = player4;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isFlagPickedUp && other.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null && !player.HasFlag)
            {
                audio.Play();
                player.HasFlag = true;
                playerWithFlag = other.gameObject;
                transform.parent = other.transform;
                transform.localPosition = new Vector3(0, 1f, -0.40f); //where the flag ends up on the back
                isFlagPickedUp = true;
                if(flagsCount.ContainsKey(player))
                {
                    flagsCount[player]++;
                    Debug.Log(flagsCount);
                }
                else
                {
                    flagsCount[player] = 0;
                }
            }
        }
        else if (isFlagPickedUp && other.CompareTag("FlagDropZone"))
        {
            PlayerController player = playerWithFlag.GetComponent<PlayerController>();
            if (player != null && player.HasFlag)
            {
                audio.Play();
                player.HasFlag = false;
                transform.parent = null;
                transform.position = other.transform.position;
                transform.localPosition = new Vector3(100, 0, 0); //sends the flag away so it looks like it dissapears 
                flagDropTime = Time.time;
                isFlagPickedUp = false;
                StartCoroutine(FlagRespawn());
                player.FlagScore++;
                Debug.Log(player.FlagScore);
            }
        }
        
        
    }
    public Dictionary<PlayerController,int> AssignPoints()
    {
        var sortedPLayers = flagsCount.OrderByDescending(x => x.Value);
        var groups=sortedPLayers.GroupBy(x => x.Value);
        int points = flagsCount.Count;
        foreach (var group in groups)
        {
            foreach (var player in group)
            {
                player.Key.FlagScore += points;
            }
            points--;
        }
        return flagsCount;
    }
   


    private IEnumerator FlagRespawn()
    {
        yield return new WaitForSeconds(flagRespawnTime);
        transform.position = flagOriginalPosition;
    }

    public float FlagDropTime()
    {
        return flagDropTime;
    }

    private bool CanPickUpFlag()
    {
        return Time.time > flagDropTime + flagRespawnTime;
    }


}