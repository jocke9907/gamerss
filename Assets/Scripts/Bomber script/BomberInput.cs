using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;
using UnityEngine.Windows;
using System;
using UnityEngine.InputSystem;

public class BomberInput : MonoBehaviour
{


    // this script is not in use. Moved to PlayerController

    //public static PlayerController Instance { get; private set; }  [SerializeField]

    private PlayerController playerController;

    bool playerDead;
    bool scoreGiven;
  

    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask markerLayerMask;
    [SerializeField] private LayerMask dropLayerMask;
    private PlayerController action;
    private bool placeBomb = false;
    private MarkerInteract selectedMarker;
    BomberManger bomberManger;
    private Vector2 movement = Vector2.zero;
    public bool canPlaceBomb = true;
    public bool veryDead = false;
   
    public void UpdateTo()
    {
        playerController = FindObjectOfType<PlayerController>();
        HandleInteractions();
        //CheckIfPlayerDead();
    }

    public void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        

        if (selectedMarker != null)
        {

            selectedMarker.Interact();
        }

        Vector2 inputVector = playerController.movementInput;

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);


        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        float intercartDistace = 2f;
        if (Physics.Raycast(transform.position, moveDir, out RaycastHit raycastHit, intercartDistace, markerLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out MarkerInteract marker))
            {                
                marker.Interact();
            }
        }
    }
    
    private Vector3 lastInteractDir;

    private void HandleInteractions()
    {

        if (playerController.inputE == true)
        {
            placeBomb = true;
        }
        else
        {
            placeBomb = false;
        }

        
        Vector2 inputVector = playerController.movementInput;
        Vector3 moveDirGround = new Vector3(inputVector.x, -1f, inputVector.y);
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float intercartDistace = 2f;

        //Checks air
        if (moveDirGround != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        if (Physics.Raycast(transform.position, moveDir, out RaycastHit raycastHitAir, intercartDistace, markerLayerMask))
        {
            if (raycastHitAir.transform.TryGetComponent(out MarkerInteract marker))
            {
                marker.Interact();
            }
            if (raycastHitAir.transform.TryGetComponent(out Bomb bomb))
            {
                bomb.Interact();
            }            
        }
        
        // Checks ground
        if (moveDirGround != Vector3.zero)
        {
            lastInteractDir = moveDirGround;
        }

        Component component = playerController.transform;

        if (Physics.Raycast(component.transform.position, moveDirGround, out RaycastHit raycastHit, intercartDistace))
        {
            if (raycastHit.transform.TryGetComponent(out MarkerInteract marker) && placeBomb)
            {
                // has marker
                marker.Interact();
            }
            if (raycastHit.transform.TryGetComponent(out Bomb bomb))
            {
                // Has bomb
                bomb.Interact();
            }
           

        }
        else
        {
            //Debug.Log("-");
        }
    }
}
