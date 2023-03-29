using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (characterMovement.isGrounded && Input.GetKeyDown(characterMovement.attackButton))
                anim.SetBool("Attacking", true);
            else
                anim.SetBool("Attacking", false);
            if (characterMovement.isGrounded && Input.GetKeyDown(characterMovement.jumpButton))
            {
                
                GetComponent<Rigidbody>().AddForce(new Vector3(0, characterMovement.jumpForce, 0));
                anim.SetBool("Jumping", true);
            }
            else
                anim.SetBool("Jumping", false);

            if (oldPos != newPos)
                anim.SetBool("Running", true);
            else
                anim.SetBool("Running", false);
        }
         newPos = transform.position;
    }
}
