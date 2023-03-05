using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;
using UnityEngine.Windows;
using System;
using UnityEngine.InputSystem;

public class BomberInput : MonoBehaviour
{

    //public static PlayerController Instance { get; private set; }

    [SerializeField] private PlayerController playerController;

    public event EventHandler<OnSelectedCounterChangedEventargs> OnSelectedMarkerChanged;
    public class OnSelectedCounterChangedEventargs : EventArgs
    {
        public MarkerInteract selectedMarker;
    }

    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask markerLayerMask;
    private PlayerController action;
    private bool inputE = false;
    private MarkerInteract selectedMarker;

    private Vector2 movement = Vector2.zero;

    public void UpdateTo()
    {
        HandleInteractions();
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
                // has CelarCouter
                marker.Interact();
            }
        }
    }
    private void SetSelctedMarker(MarkerInteract selectedMarker)
    {
        this.selectedMarker = selectedMarker;
        OnSelectedMarkerChanged?.Invoke(this, new OnSelectedCounterChangedEventargs
        {
            selectedMarker = selectedMarker
        });
    }
    private Vector3 lastInteractDir;


    /// <summary>
    /// /
    /// </summary>

    //private void OnMove(InputAction.CallbackContext context)
    //{
    //    movement = context.ReadValue<Vector2>();
    //}/// 


    private void HandleInteractions()
    {

        if (inputE == true)
        {
            Debug.Log("e");
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

        Component component = playerController.transform;

        if (Physics.Raycast(component.transform.position, moveDirGround, out RaycastHit raycastHit, intercartDistace))
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
