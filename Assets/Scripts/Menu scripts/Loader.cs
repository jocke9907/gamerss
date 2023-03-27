using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public static class Loader
{

    public static bool bomberGamePlaying;
    public enum Scene
    {
        Loading, Menu, CreateGame, BomberGame, 
    }
    //Scene curentGameState = Scene.Menu;

    private static Action onLoaderCallBack;

    public static void Load(Scene scene)
    {
        //set the loader callback action to load the target scene
        onLoaderCallBack = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };

        // load the Loading scene
        SceneManager.LoadScene(Scene.Loading.ToString());

    }

    public static void LoaderCallBack()
    {
        // Triger after the first Update which lets the scene refresh
        // Execute the loader callback action which will load the target scene
        if (onLoaderCallBack != null)
        {
            onLoaderCallBack();
            onLoaderCallBack = null;
        }

    }
    

}
