using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //
    public static PlayerController Instance { get; private set; }
    public static Component component { get; private set; }

    //public event EventHandler<OnSelectedCounterChangedEventargs> OnSelectedMarkerChanged;
    //public class OnSelectedCounterChangedEventargs : EventArgs
    //{
    //    public MarkerInteract selectedMarker;
    //}

    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask markerLayerMask;
    private PlayerController action;


    //private MarkerInteract selectedMarker;


    // [SerializeField]
    private BomberInput bomberInput;
    private ChangeMap changeMap;
    //public BomberInput bomberInput;
    

    public CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    private float playerSpeed = 5.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public Vector2 movementInput { get; private set; } = Vector2.zero;
    
    private bool jumped = false;
    public bool inputE = false;


    private void Start()
    {
        bomberInput = FindObjectOfType<BomberInput>();

        changeMap = FindObjectOfType<ChangeMap>();
        
        controller = gameObject.GetComponent<CharacterController>();

        
        //gameInput.OnInteractAction += bomberInput.GameInput_OnInteractAction;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        
        inputE = context.action.triggered;
        
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



        //HandleInteractions();
        //bomberInput.UpdateTo();

        if(Loader.bomberGamePlaying == true) 
        { 
             bomberInput.UpdateTo();
        }
       

    }


   
    

    ///!!!!!!! ta inte bort


    ////new
    //private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    //{
    //    if (selectedMarker != null)
    //    {

    //        selectedMarker.Interact(); 
    //    }

    //    Vector2 inputVector = movementInput;

    //    Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);


    //    if (moveDir != Vector3.zero)
    //    {
    //        lastInteractDir = moveDir;
    //    }

    //    float intercartDistace = 2f;
    //    if (Physics.Raycast(transform.position, moveDir, out RaycastHit raycastHit, intercartDistace, markerLayerMask))
    //    {
    //        if (raycastHit.transform.TryGetComponent(out MarkerInteract marker))
    //        {
    //            // has CelarCouter
    //            marker.Interact();
    //        }
    //    }
    //}
    //private void SetSelctedMarker(MarkerInteract selectedMarker)
    //{
    //    this.selectedMarker = selectedMarker;
    //    OnSelectedMarkerChanged?.Invoke(this, new OnSelectedCounterChangedEventargs
    //    {
    //        selectedMarker = selectedMarker
    //    });
    //}
    //private Vector3 lastInteractDir;


    ///// <summary>
    ///// /
    ///// </summary>

    //private void HandleInteractions()
    //{

    //    if (inputE == true)
    //    {
    //        Debug.Log("e");
    //    }


    //    Vector2 inputVector = movementInput;

    //    Vector3 moveDirGround = new Vector3(inputVector.x, -1f, inputVector.y);
    //    Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

    //    float intercartDistace = 2f;

    //    //Checks air
    //    if (moveDirGround != Vector3.zero)
    //    {
    //        lastInteractDir = moveDir;
    //    }

    //    if (Physics.Raycast(transform.position, moveDir, out RaycastHit raycastHitAir, intercartDistace, markerLayerMask))
    //    {
    //        if (raycastHitAir.transform.TryGetComponent(out MarkerInteract marker))
    //        {
    //            // has marker
    //            marker.Interact();
    //        }
    //        if (raycastHitAir.transform.TryGetComponent(out Bomb bomb))
    //        {
    //            // 
    //            bomb.Interact();
    //        }
    //        //Debug.Log(raycastHit.transform);

    //    }

    //    // Checks ground
    //    if (moveDirGround != Vector3.zero)
    //    {
    //        lastInteractDir = moveDirGround;
    //    }

    //    if (Physics.Raycast(transform.position, moveDirGround, out RaycastHit raycastHit, intercartDistace))
    //    {
    //        if (raycastHit.transform.TryGetComponent(out MarkerInteract marker))
    //        {
    //            // has marker
    //            marker.Interact();                
    //        }
    //        if (raycastHit.transform.TryGetComponent(out Bomb bomb))
    //        {
    //            // Has bomb
    //            bomb.Interact();
    //        }
    //        //Debug.Log(raycastHit.transform);

    //    }       
    //    else
    //    {
    //        Debug.Log("-");
    //    }        
    //}
}