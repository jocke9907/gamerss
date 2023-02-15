using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{
    public CharacterMovement characterMovement;
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
            if (Input.GetKeyDown(characterMovement.jumpButton))
            {
                anim.SetBool("Jumping", true);
               
            }
            if (oldPos != newPos && characterMovement.isGrounded)
            {
                anim.SetBool("Jumping", false);
                anim.SetBool("Running", true);
            }
            else
                anim.SetBool("Running", false);
        }
        newPos = transform.position;
    }
}
