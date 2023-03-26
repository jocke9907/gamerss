using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameUI : MonoBehaviour
{
    public void ChangeSceneBomber()
    {      
        Loader.Load(Loader.Scene.BomberGame);
    }
}
