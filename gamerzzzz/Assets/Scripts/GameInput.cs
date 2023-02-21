using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;

    private PlayerController playerInputActions;

    //private void Awake()
    //{
    //    playerInputActions = new PlayerInputActions();
    //    playerInputActions.Player.Enable();

    //    playerInputActions.Player.Interact.performed += Interact_performed;
    //}

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);

    }
}
