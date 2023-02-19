using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    
    

    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private Vector2 movementInput = Vector2.zero;
    private bool jumped = false;
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        
        jumped = context.action.triggered;
    }

    void Update()
    {
        
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
          
           
        }

        // Changes the height position of the player..
        if (jumped && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


        HandleInteractions();
    }


    // new
   
    private Vector3 lastInteractDir;
    
    private void HandleInteractions()
    {

        Vector2 inputVector = movementInput;
        



        Vector3 moveDirGround = new Vector3(inputVector.x, -1f, inputVector.y);
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float intercartDistace = 2f;

        //Checks air
        if (moveDirGround != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        if (Physics.Raycast(transform.position, moveDir, out RaycastHit raycastHitAir, intercartDistace))
        {
            if (raycastHitAir.transform.TryGetComponent(out MarkerInteract marker))
            {
                // has marker
                marker.Interact();
            }
            if (raycastHitAir.transform.TryGetComponent(out Bomb bomb))
            {
                // 
                bomb.Interact();
            }
            //Debug.Log(raycastHit.transform);

        }

        // Checks ground
        if (moveDirGround != Vector3.zero)
        {
            lastInteractDir = moveDirGround;
        }

        if (Physics.Raycast(transform.position, moveDirGround, out RaycastHit raycastHit, intercartDistace))
        {
            if (raycastHit.transform.TryGetComponent(out MarkerInteract marker))
            {
                // has marker
                marker.Interact();                
            }
            if (raycastHit.transform.TryGetComponent(out Bomb bomb))
            {
                // Has bomb
                bomb.Interact();
            }
            //Debug.Log(raycastHit.transform);

        }       
        else
        {
            Debug.Log("-");
        }

        
    }
}