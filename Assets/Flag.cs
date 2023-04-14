using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject flagRespawnPoint;
    public float flagRespawnTime = 5f;
    PlayerScore score;


    private static bool hasFlag = false;
    private Vector3 flagOriginalPosition;
    private float flagDropTime;
    private GameObject playerWithFlag;


    void Start()
    {
        flagOriginalPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!hasFlag && other.CompareTag("Player"))
        {
            hasFlag = true;
            Debug.Log(hasFlag);
            playerWithFlag = other.gameObject;
            transform.parent = other.transform;
            transform.localPosition = new Vector3(0, 1f, -0.40f);
        }
        else if (hasFlag && other.CompareTag("FlagDropZone"))
        {
            hasFlag = false;
            transform.parent = null;
            transform.position = other.transform.position;
            transform.localPosition = new Vector3(100, 0, 0);
            flagDropTime = Time.time;
            StartCoroutine(FlagRespawn());
            //score.currentScore++;
            
        }

    }
    private IEnumerator FlagRespawn()
    {
        yield return new WaitForSeconds(flagRespawnTime);
        transform.position = flagOriginalPosition;
    }
    public bool HasFlag()
    {
        return hasFlag;
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
