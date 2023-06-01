using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;

using UnityEditor;


public class MarkerInteract : MonoBehaviour
{
    // handels all the interactions with the player and the markers. 
    // handels bombExplotions 

    [SerializeField] private Transform bombPrefab;
    [SerializeField] private Transform bombUp1Prefab;
    [SerializeField] private Transform bombSpawn;
    [SerializeField] private Transform dropPrefab;
    [SerializeField] private Transform dropSpawn;

    [SerializeField] private LayerMask barralLayerMask;
    [SerializeField] private LayerMask playerLayer;

    private Barral Barral;
    PlayerController playerController;
    PlayerScore playerScore;
    PlayerLevel playerLevel;
    BomberInput bomberInput;
    BomberManger bomberManger;
    private Vector3 lastInteractDir;
    public Vector3 reset = new Vector3 (0, 40, 0);

    //playerController = FindObjectOfType<BomberInput>();
    public bool randomBomb = true;

    Vector3 explodeDir = new Vector3(1, 0, 0);

    public float targetTime = 4.1f;
    Vector2 inputVector = new Vector2(8f, 0f);
    float vectorZ = .1f;
    bool firstBombPlaced;
    bool bomPlaced;
    public bool canPlaceBomb = true;
    InputSystemEnabler enabler;
    int uppgrade = 8;
    public void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        bomberInput = FindObjectOfType<BomberInput>();
        bomberManger = FindObjectOfType<BomberManger>();
        enabler = FindObjectOfType<InputSystemEnabler>();
    }

    
    public void Interact()
    {
       

        if (bomberManger.bombUppgrade > uppgrade)
        {
            Transform bombTransform = Instantiate(bombUp1Prefab, bombSpawn);
            bombTransform.localPosition = Vector3.zero;
            targetTime = 4.1f;
        }
        else if(bomberManger.bombUppgrade <= uppgrade)
        {
            Transform bombTransform = Instantiate(bombPrefab, bombSpawn);
            bombTransform.localPosition = Vector3.zero;
            targetTime = 4.1f;
        }



        targetTime = 4.1f;
        bomPlaced = true;
        firstBombPlaced = true;

        canPlaceBomb = false;

        //bomberInput.canPlaceBomb = false;
    }

    
    private void DropChance()
    {
        int dropChance = Random.Range(1, 7);
        if (dropChance == 1 ) 
        {
            Transform dropTansform = Instantiate(dropPrefab, dropSpawn);
            //Debug.Log("drop");
        }
    }

    void ExplotionCollider()
    {
        float maxDistans = 6f;
        

        Quaternion rotation = new Quaternion(0, 0, 0, 0);
        Vector3 volym = new Vector3(1.5f, 4f, 1.5f);
        //Vector3 explodeDir = new Vector3(1, 0, 0);
        //if (explodeDir != Vector3.zero)
        //{
        //    lastInteractDir = explodeDir;
        //}
        //Physics.BoxCastAll(transform.position, transform.lossyScale, explodeDir, transform.rotation, maxDistans, barralLayerMask, QueryTriggerInteraction.Collide);
        

        
        
        Vector3 area = new Vector3(3,3,3);
        if (explodeDir != Vector3.zero)
        {
            lastInteractDir = explodeDir;
        }
        if (Physics.BoxCast(transform.position, volym , explodeDir, out RaycastHit raycastHit, transform.rotation, maxDistans, barralLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out Barral barral))
            {
                barral.InteractB();
                //DropChance();
            }
        }

        if (Physics.BoxCast(transform.position, volym, explodeDir, out RaycastHit raycastHitPlayer, transform.rotation, maxDistans, playerLayer))
        {
            if (raycastHitPlayer.transform.TryGetComponent(out PlayerController playerController))
            {
                if (playerController.veryDead == false)
                {
                    bomberManger.redusePlayers = true;
                    bomberManger.bomberPoints -= 1;
                    playerController.totalScore -= bomberManger.bomberPoints;
                    playerController.veryDead = true;
                }
            }
        }

        

    }
    private void OnDrawGizmos()
    {
        Vector3 volym = new Vector3(2f, 4f, 2f);
        //Vector3 explodeDir = new Vector3(1, 0, 0);
        Quaternion rotation = new Quaternion(0, 0, 0, 0);
        Vector3 area = new Vector3(5, 5, 5);
        Gizmos.color = new UnityEngine.Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireCube(transform.position+ explodeDir , volym );
    }
    public  void DrawBoxCastOnHit()
    {
       
    }


    void Explode()
    {
        // same script as above but with Raycast
       
        float maxDistans = 13f ;
       
       
        Vector3 explodeDir = new Vector3(inputVector.x, vectorZ, inputVector.y);
        if (explodeDir != Vector3.zero)
        {
            lastInteractDir = explodeDir;
        }

        if (Physics.Raycast(transform.position , explodeDir,  out RaycastHit raycastHit, maxDistans, barralLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out Barral barral))
            {
                
                barral.InteractB(); 
                //DropChance();
            }
            
        }
        if (explodeDir != Vector3.zero)
        {
            lastInteractDir = explodeDir;
        }
        if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), explodeDir, out RaycastHit raycastHitPlayer, maxDistans, playerLayer))
        {           
            if (raycastHitPlayer.transform.TryGetComponent(out PlayerController playerController))
            {
                if (playerController.veryDead == false)
                {
                    bomberManger.redusePlayers = true;
                    bomberManger.bomberPoints -= 1;
                    playerController.totalScore -= bomberManger.bomberPoints;
                    playerController.veryDead = true;
                }
                
            }
        }

    }
    
    void Update()
    {
        //OnDrawGizmos();
        //Debug.Log(bomberInput.canPlaceBomb);
        if (bomPlaced)
        {
            canPlaceBomb = false;
            //OnDrawGizmosSelected();
            //----
            //bomberInput.canPlaceBomb = false;
            targetTime -= Time.deltaTime;
        }

        
        if (firstBombPlaced && targetTime <= 0.5f)
        {
            timerEnded();
            firstBombPlaced = false;
        }

        if ( bomPlaced && targetTime <= 0.0f)
        {
            timerEnded();

            //Debug.Log("timer");
            canPlaceBomb = true;
            //bomberInput.canPlaceBomb = true;
            bomPlaced = false;
        }
    }
    public void DestroyMarker()
    {
        Destroy(gameObject);
    }
    void timerEnded()
    {
        explodeDir = new Vector3(1, 0, 0);
        ExplotionCollider();
        explodeDir = new Vector3(-1, 0, 0);
        ExplotionCollider();
        explodeDir = new Vector3(0, 0, 1);
        ExplotionCollider();
        explodeDir = new Vector3(0, 0, -1);
        ExplotionCollider();



        //förstör markern och det som har spawnat på den
        // destroys the ground- not used
        if (bomberManger.bombUppgrade >uppgrade)
        {

            DestroyMarker();
        }
        //Destroy(gameObject);
        //DestroyMarker();
    }
}
