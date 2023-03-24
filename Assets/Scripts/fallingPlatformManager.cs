using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatformManager : MonoBehaviour
{
    
   List<GameObject> platforms = new List<GameObject>();
    float targetTime = 5.0f;
    int randomObj;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Ground")
            {
                platforms.Add(child.gameObject);
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        if(targetTime <= 0.0f)
        {
            Debug.Log("Platform ska falla");
            targetTime= 5.0f;
            randomObj = Random.Range(0, platforms.Count);
            /*platforms[randomObj] *///SET GRAVITY TRUE?
            platforms.RemoveAt(randomObj);

        }
    }

    

}
