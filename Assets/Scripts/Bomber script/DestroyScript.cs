using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public GameObject obj;
    void Start()
    {
        Destroy(obj, 4);
    }

   
}
