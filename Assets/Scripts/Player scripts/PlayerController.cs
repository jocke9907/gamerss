using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //


    public bool playerOne;
    public bool playerTwo;
    public bool playerThree;
    public bool playerFour;
    public bool no; //icke bra
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

    public bool HasFlag { get; set; } //picked up flag or not
    public int FlagScore { get; set; }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player Collided with collider");
    }


    //private MarkerInteract selectedMarker;
    public int totalScore;

    // [SerializeField]
    private BomberInput bomberInput;
    private WallClimberInput wallClimberInput;
    private ChangeMap changeMap;
    BomberManger bomberManger;
    //public BomberInput bomberInput;

    //Animator
    [SerializeField] Animator anim;

    //Sound
    [SerializeField] AudioSource jumpAudio;
    [SerializeField] AudioSource bombAudio;

    public CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    public float playerSpeed = 5.0f;
    private float jumpHeight = 2.75f;
    private float gravityValue = -9.81f;
    public Vector2 movementInput { get; private set; } = Vector2.zero;
    float jumpCooldown = 0;
    float jumpTimer = 1f;
    private bool jumped = false;
    public bool inputE = false;
    public bool grab = false;


    //------------Sam----------------------------------

    public bool sam = false;
    public float maxGrabDistance = 1f;
    public KeyCode grabButton = KeyCode.Tab;
    //public KeyCode testButton;
    public GameObject grabbedObject = null;
    private Vector3 objectOffset = Vector3.zero;

    public Transform grabPoint;
    public LayerMask movable;
    BoxCollider bc;
    Rigidbody rb;
    float test;
    public bool alreadyGrabbed = false;
    public bool finished = false;
    public int tempScore = 0;
    public bool jumpingAllowed = true;

    //--------------------------------------------------
    //[SerializeField] private GameInput gameInput;
    //[SerializeField] private LayerMask markerLayerMask;
    [SerializeField] private LayerMask dropLayerMask;
    //private PlayerController action;
    [SerializeField] bool placeBomb = false;
    private MarkerInteract selectedMarker;
    private Vector2 movement = Vector2.zero;
    public bool canPlaceBomb = true;
    public bool veryDead = false;
    bool scoreGiven = false;
    bool scoreGivenLava = false;


    public PlayerInput playerInput;




    public void Awake()
    {
        bomberManger = FindObjectOfType<BomberManger>();
        playerInput = GetComponent<PlayerInput>();

        var particleSystem = GetComponentInChildren<ParticleSystem>();
        var emissionModule = particleSystem.emission;
        emissionModule.enabled = false;

        //GetComponentInChildren<ParticleSystem>().enableEmission = false;
        GetComponentInChildren<Light>().enabled = false;
    }
    private void Start()
    {

        
        bomberInput = FindObjectOfType<BomberInput>();

        wallClimberInput = FindObjectOfType<WallClimberInput>();

        changeMap = FindObjectOfType<ChangeMap>();

        controller = gameObject.GetComponent<CharacterController>();

        FindObjectOfType<PlayerManager>().AddToList(this);


        //gameInput.OnInteractAction += bomberInput.GameInput_OnInteractAction;
    }
    public void DisableInput()
    {
        playerInput.DeactivateInput();
    }

    public void EnableInput()
    {
        playerInput.ActivateInput();
    }
    public void AddPoints(int pointsToAdd)
    {
        totalScore += pointsToAdd;
    }
    public int GetScore()
    {
        return totalScore;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        anim.SetTrigger("Interacting");
        inputE = context.action.triggered;
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (jumpingAllowed)
        {

            jumped = context.action.triggered;
            

        }
    }
    public void OnGrab(InputAction.CallbackContext context)
    {
        grab = context.action.triggered;

    }

    void Update()
    {

        //GetComponent<ParticleSystem>().enableEmission = false;
        if (veryDead)
        {
            var particleSystem = GetComponentInChildren<ParticleSystem>();
            var emissionModule = particleSystem.emission;
            emissionModule.enabled = true;
            //GetComponentInChildren<ParticleSystem>().enableEmission = true;
            GetComponentInChildren<Light>().enabled = true;

            return;
        }

        //Debug.Log(jumpCooldown);
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            anim.SetBool("Running", true);
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10);
            //gameObject.transform.forward = move;
        }
        else
            anim.SetBool("Running", false);

        // Changes the height position of the player..

        if (jumped && groundedPlayer)
        {
            if (jumpCooldown <= 0)
            {
                jumpAudio.Play();
                anim.SetBool("Jumping", true);
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

                jumpCooldown = jumpTimer;
            }
        }
        else
            anim.SetBool("Jumping", false);
        if (jumpCooldown > 0)
        {
            jumpCooldown -= Time.deltaTime;
        }


        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);



        //HandleInteractions();
        //bomberInput.UpdateTo();
        GiveScoreLavaGround();
        if (Loader.bomberGamePlaying == true)
        {
            UpdateTo();
            GetComponent<BoxCollider>().enabled = true;

        }
        else
        {
            GetComponent<BoxCollider>().enabled = false;
        }
        if (Loader.wallClimberPlaying == true)
        {
            //wallClimberInput.UpdateWallClimberTo();
            GrabObject();
        }

        if (sam == true)
        {
            GrabObject();
        }

    }

    private void FixedUpdate()
    {
        //Bara respawn ifall man ramlar utanför

        //if (Loader.PlatformGamePlaying)
        //{
        //    if (transform.position.y <= -40)
        //    {
        //        transform.position = new Vector3(0, 3, 0);
        //    }
        //}

    }

    //----------------------------------------SAM-----------------------------------------------------------------------
    private void GrabObject()
    {
        if (grab)
        {

            RaycastHit hit;
            Debug.Log("casting");
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxGrabDistance, movable))
            {
                //anim.SetBool("Grabbing", true);
                if (alreadyGrabbed == false)
                {
                    Debug.Log("hit");
                    grabbedObject = hit.collider.gameObject;

                    bc = grabbedObject.GetComponent<BoxCollider>();
                    rb = grabbedObject.GetComponent<Rigidbody>();
                    alreadyGrabbed = true;
                }


            }
        }
        if (!grab && grabbedObject != null && alreadyGrabbed == true)
        {
            //anim.SetBool("Grabbing", false);
            grabbedObject = null;
            alreadyGrabbed = false;
        }

        if (grabbedObject != null)
        {

            rb.mass = 1;
            //bc.isTrigger = true;
            //grabbedObject.transform.rotation = Quaternion.identity.x;
            //grabbedObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            Quaternion newRotation = Quaternion.Euler(0f, grabPoint.rotation.eulerAngles.y, 0f);
            grabbedObject.transform.rotation = newRotation;
            //rb.useGravity = false;
            playerSpeed = 2.5f;
            grabbedObject.transform.position = grabPoint.position;

        }
        else
        {

            playerSpeed = 5f;
            //bc.isTrigger = false;
            //rb.mass = 1000;
            if (rb)
                rb.mass = 1000;
            //movementScript.speed = (int)5;
        }

    }

    //----------------SAM-----------------------------------------------------------------------------------------------


    public void AddScore(int score)
    {
        tempScore = score;
        totalScore = totalScore + score;
    }


    //------------------------------------------------------------------------------------------------------------------

    public void UpdateTo()
    {
        //playerController = FindObjectOfType<PlayerController>();
        HandleInteractions();
        GiveScoreBomb();
        //CheckIfPlayerDead();
    }
    public void GiveScoreBomb()
    {


        if (!scoreGiven && bomberManger.bomberPlayed)
        {
            totalScore += 4;
            scoreGiven = true;
        }
    }
    public void GiveScoreLavaGround()
    {


        if (!scoreGivenLava && bomberManger.lavaGroundPlayed)
        {
            totalScore += 4;
            scoreGivenLava = true;
        }
    }
    public void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {


        if (selectedMarker != null)
        {
            selectedMarker.Interact();
        }

        Vector2 inputVector = movementInput;

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

        if (inputE == true)
        {
            bombAudio.Play();
            placeBomb = true;
        }
        else if (inputE == false)
        {
            placeBomb = false;
        }


        Vector2 inputVector = movementInput;
        Vector3 moveDirGround = new Vector3(inputVector.x, -1f, inputVector.y);
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float intercartDistace = 2f;

        //Checks air
        //if (moveDirGround != Vector3.zero)
        //{
        //    lastInteractDir = moveDir;
        //}

        //if (Physics.Raycast(transform.position, moveDir, out RaycastHit raycastHitAir, intercartDistace, markerLayerMask))
        //{
        //    if (raycastHitAir.transform.TryGetComponent(out MarkerInteract marker))
        //    {
        //        //marker.Interact();
        //    }
        //    if (raycastHitAir.transform.TryGetComponent(out Bomb bomb))
        //    {
        //        bomb.Interact();
        //    }
        //}

        // Checks ground
        if (moveDirGround != Vector3.zero)
        {
            lastInteractDir = moveDirGround;
        }

        Component component = transform;

        if (Physics.Raycast(component.transform.position, moveDirGround, out RaycastHit raycastHit, intercartDistace))
        {
            if (placeBomb && raycastHit.transform.TryGetComponent(out MarkerInteract marker))
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