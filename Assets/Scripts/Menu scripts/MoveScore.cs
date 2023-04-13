using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScore : MonoBehaviour
{

    PlayerController playerController;
   [SerializeField] int height;
    public void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void MoveBlock()
    {
        playerController.totalScore = height;
    }
    public void Update()
    {
        MoveBlock();
        transform.position = new Vector3(-10.5f,(height) -5,8);
    }
}
