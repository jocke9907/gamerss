using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fallingObject : MonoBehaviour
{

    LayerMask player;
    List<GameObject> listObject = new List<GameObject>();
    void Start()
    {

        foreach (Transform child in transform)
        {
            if(child.gameObject.tag == "Movable object" || child.gameObject.tag == "Player")
            {
                listObject.Add(child.gameObject);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float randX = Random.Range(-5, 5);
        float randz = Random.Range(-5, 5);

        foreach (GameObject child in listObject)
        {
            if (child.transform.position.y < -10)
            {
                child.transform.position = new Vector3(randX, 25, randz);
            }
        }
        
    }
}
