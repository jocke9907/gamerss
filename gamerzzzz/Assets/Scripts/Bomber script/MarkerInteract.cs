using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerInteract : MonoBehaviour
{
    [SerializeField] private Transform bombPrefab;
    [SerializeField] private Transform bombSpawn;
    public float targetTime = 20.0f;
    public void Interact()
    {
        Debug.Log("Interact marker!");
        Transform bombTransform  =Instantiate(bombPrefab, bombSpawn);
        bombTransform.localPosition = Vector3.zero;
        targetTime = 20.0f;
        
    }
    


    void Update()
    {
        //Debug.Log("updating");
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
    }
    

    void timerEnded()
    {
        Debug.Log("bomb explod");

        Destroy(gameObject);
    }
}
