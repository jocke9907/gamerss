using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{
    [SerializeField] int playerRequired = 1;
    int playersFinished = 0;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;
        if (hitObject.tag == "Player")
        {
            playersFinished++;
            if(playersFinished == playerRequired)
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //SceneManager.LoadScene("PostLobby");
                Loader.Load(Loader.Scene.PostLobby);
            }
            
        }
    }
}
