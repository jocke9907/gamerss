using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fallingObject : MonoBehaviour
{
    List<GameObject> listObject = new List<GameObject>();
    void Start()
    {

        foreach (Transform child in transform)
        {
            if(child.gameObject.tag == "Movable object")
            {
                listObject.Add(child.gameObject);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject child in listObject)
        {
            if (child.transform.position.y < -10)
            {
                child.transform.position = new Vector3(0, 10, 0);
            }
        }
        
    }
}
