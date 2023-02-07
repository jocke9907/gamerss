using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator anim;
    Vector3 oldPos;
    Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         oldPos = transform.position;
        if (anim != null)
        {
            if (oldPos != newPos)
                anim.SetBool("Running", true);
            else
                anim.SetBool("Running", false);
        }
         newPos = transform.position;
    }
}
