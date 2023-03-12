using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerInteract : MonoBehaviour
{
    [SerializeField] private Transform bombPrefab;
    [SerializeField] private Transform bombSpawn;
    public void Interact()
    {
        Debug.Log("Interact marker!");
        Transform bombTransform  =Instantiate(bombPrefab, bombSpawn);
        bombTransform.localPosition = Vector3.zero;
    }
}
