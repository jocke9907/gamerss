using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject flagRespawnPoint; 
    public float flagRespawnTime = 5f;
    //public Transform playerBack;

    private bool hasFlag = false;
    private Vector3 flagOriginalPosition;
    private float flagDropTime;

    void Start()
    {
        flagOriginalPosition = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!hasFlag && other.CompareTag("Player"))
        {
            hasFlag = true;
            
            transform.parent = other.transform;
            transform.localPosition = new Vector3(0, 1f, -0.40f);
        }
        else if (hasFlag && other.CompareTag("FlagDropZone"))
        {
            hasFlag = false;
            transform.parent = null;
            transform.position = other.transform.position;
            flagDropTime = Time.time;
            StartCoroutine(FlagRespawn());
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
