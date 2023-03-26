using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneUI : MonoBehaviour
{
    public void ChangeScene()
    {
        Debug.Log("Clicked CreateGame");
        Loader.Load(Loader.Scene.CreateGame);
    }
}
