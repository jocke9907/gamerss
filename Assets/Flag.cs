using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
    

    void Start()
    {
        audio = GetComponent<AudioSource>();
        flagOriginalPosition = transform.position;
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
    public void AssignScore()
    {
        //var sortedPlayers=
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