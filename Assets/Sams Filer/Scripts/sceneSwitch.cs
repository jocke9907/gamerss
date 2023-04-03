using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{
    [SerializeField] int finishedPlayers = 0;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;
        if (hitObject.tag == "Player")
        {
            finishedPlayers++;
            if(finishedPlayers >= 4)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //SceneManager.LoadScene("PostLobby");
            }
            
        }
    }
}
