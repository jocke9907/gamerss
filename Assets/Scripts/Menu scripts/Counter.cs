using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    BomberManger bomberManger;
    public int numbr;
    private void Start()
    {
        bomberManger = FindObjectOfType<BomberManger>();
    }

    public void Count()
    {
        if (numbr == bomberManger.playerCountBomber +1)
        {
            Loader.Load(Loader.Scene.PostLobby);
        }
    }

    private void Update()
    {
        Count();
    }
}
