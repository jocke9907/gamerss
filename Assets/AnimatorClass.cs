using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatorClass : MonoBehaviour
{
    [SerializeField] Animator anim;
    Vector3 oldPos;
    Vector3 currentPos;
    [SerializeField] CharacterController controller;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        anim.SetBool("Running", true);
    }
}
