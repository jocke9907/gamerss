using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MarkerInteract : MonoBehaviour
{
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
    BomberInput bomberInput;


    //playerController = FindObjectOfType<BomberInput>();
    public bool randomBomb = true;

    public float targetTime = 4.0f;
    Vector2 inputVector = new Vector2(1f, 0f);
    float vectorZ;
    bool bomPlaced;
    //bool canPlaceBomb = true;
    public void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        bomberInput = FindObjectOfType<BomberInput>();
    }

    //public void DropBombs()
    //{
    //    Debug.Log("yes");
    //    Transform bombTransform = Instantiate(bombUp1Prefab, bombSpawn);
    //    bombTransform.localPosition = Vector3.zero;
    //    randomBomb = false;
    //}
    public void Interact()
    {
        //Debug.Log("Interact marker!");
        //if (bomberInput.canPlaceBomb == true)
        //{
        //    if(BomberManger.bombUppgrade >1)
        //    {
        //        Transform bombTransform = Instantiate(bombUp1Prefab, bombSpawn);
        //        bombTransform.localPosition = Vector3.zero;
        //    }
        //    else
        //    {
        //        Transform bombTransform = Instantiate(bombPrefab, bombSpawn);
        //        bombTransform.localPosition = Vector3.zero;
        //    }



        //    targetTime = 4.0f;
        //    bomPlaced = true;
        //    bomberInput.canPlaceBomb = false;
        //}        
        if (BomberManger.bombUppgrade > 4)
        {
            Transform bombTransform = Instantiate(bombUp1Prefab, bombSpawn);
            bombTransform.localPosition = Vector3.zero;
        }
        else
        {
            Transform bombTransform = Instantiate(bombPrefab, bombSpawn);
            bombTransform.localPosition = Vector3.zero;
        }



        targetTime = 4.0f;
        bomPlaced = true;
        bomberInput.canPlaceBomb = false;
    }

    public void RandomBombs()
    {

    }
    //public void StrongBomb()
    //{
    //    Debug.Log("pickUp");
    //}
    private void DropChance()
    {
        int dropChance = Random.Range(1, 8);
        if (dropChance == 1 ) 
        {
            Transform dropTansform = Instantiate(dropPrefab, dropSpawn);
            Debug.Log("drop");
        }
    }

    void Explode()
    {
        //+BomberManger.bombUppgrade*2
        float maxDistans = 10f ;
       
       
        Vector3 explodeDir = new Vector3(inputVector.x, vectorZ, inputVector.y);
        

        if (Physics.Raycast(transform.position , explodeDir,  out RaycastHit raycastHit, maxDistans, barralLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out Barral barral))
            {
                //Debug.Log("found obj");
                barral.InteractB(); 
                DropChance();
            }
            
        }

        if(Physics.Raycast(transform.position, explodeDir, out RaycastHit raycastHitPlayer, maxDistans, playerLayer))
        {           
            if (raycastHitPlayer.transform.TryGetComponent(out PlayerController playerController))
            {
                
                playerController.transform.position = new Vector3(0,40,0);
                BomberManger.playerCountBomber--;
                BomberManger.bomberPoints += 1;
                Debug.Log(BomberManger.playerCountBomber);
                BomberManger.PlayerCounter();                
            }
        }
    }
    void Update()
    {

        //Debug.Log(bomberInput.canPlaceBomb);
        if (bomPlaced == true)
        {
            bomberInput.canPlaceBomb = false;
            targetTime -= Time.deltaTime;
        }


        //&& bomPlaced == true
        if (targetTime >= -0.2f && targetTime <= 0.0f && bomPlaced == true)
        {
            timerEnded();
            bomPlaced =false;
            bomberInput.canPlaceBomb = true;
        }
    }
    
    void timerEnded()
    {
        vectorZ = 0.1f;
        Debug.Log("bomb explod");
        inputVector = new Vector2(1f, 0f);
        Explode();
        inputVector = new Vector2(0f, 1f);
        Explode();
        inputVector = new Vector2(-1f, 0f);
        Explode();
        inputVector = new Vector2(0f, -1f);
        Explode();
        vectorZ = 0.5f;
        inputVector = new Vector2(1f, 0f);
        Explode();
        inputVector = new Vector2(0f, 1f);
        Explode();
        inputVector = new Vector2(-1f, 0f);
        Explode();
        inputVector = new Vector2(0f, -1f);
        Explode();

        //förstör markern och det som har spawnat på den

        if (BomberManger.bombUppgrade >5)
        {
            Destroy(gameObject);
        }
    }
}
