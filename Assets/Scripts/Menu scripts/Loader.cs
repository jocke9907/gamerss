using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public static class Loader
{
    public static bool PlatformGamePlaying;
    public static bool bomberGamePlaying;
    public static bool TheMazePlaying;
    public enum Scene
    {
<<<<<<< Updated upstream
        Loading, Menu, CreateGame, BomberGame, ViggesScene, Lobby
=======
        Loading, Menu, CreateGame, BomberGame, ViggesScene, Lobby, CaptureTheFlag, TheMaze
>>>>>>> Stashed changes
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
