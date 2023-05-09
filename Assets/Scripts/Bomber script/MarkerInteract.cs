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
    PlayerLevel playerLevel;
    BomberInput bomberInput;
    BomberManger bomberManger;
    private Vector3 lastInteractDir;
    public Vector3 reset = new Vector3 (0, 40, 0);

    //playerController = FindObjectOfType<BomberInput>();
    public bool randomBomb = true;

    public float targetTime = 4.1f;
    Vector2 inputVector = new Vector2(8f, 0f);
    float vectorZ = .1f;
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
        //if (playerController.canPlaceBomb == true)
        //{
        //    if (bomberManger.bombUppgrade > 1)
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
        //    playerController.canPlaceBomb = false;
        //}

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

        canPlaceBomb = false;

        //bomberInput.canPlaceBomb = false;
    }

    //public void RandomBombs()
    //{
    //    if (bomberManger.bombUppgrade > 8)
    //    {
    //        Transform bombTransform = Instantiate(bombUp1Prefab, bombSpawn);
    //        bombTransform.localPosition = Vector3.zero;
    //        targetTime = 4.1f;
    //    }
    //    else if(bomberManger.bombUppgrade <= 8)
    //    {
    //        Transform bombTransform = Instantiate(bombPrefab, bombSpawn);
    //        bombTransform.localPosition = Vector3.zero;
    //        targetTime = 4.1f;
    //    }
    //}
    //public void StrongBomb()
    //{
    //    Debug.Log("pickUp");
    //}
    private void DropChance()
    {
        int dropChance = Random.Range(1, 7);
        if (dropChance == 1 ) 
        {
            Transform dropTansform = Instantiate(dropPrefab, dropSpawn);
            //Debug.Log("drop");
        }
    }

    void Explode()
    {
        //+BomberManger.bombUppgrade*2
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
                //playerController.transform.position = new Vector3(0,40,0);
                //Debug.Log("playerDead");
                //playerController.transform.position += new Vector3(0, 90, 0);
                //Debug.Log("move"+ playerController1.transform.position);
               
                //playerController.gameObject.SetActive(false);
                //enabler.gameObject.SetActive(false);
                //playerController.DeactivateInput();
                //bomberManger.playerCountBomber ;
                
                //bomberManger.playerCountBomber--;
                //if (playerDead && scoreGiven == false)
                //{
                //    Debug.Log("score given");
                //    playerScore.currentScore = playerScore.currentScore + bomberManger.bomberPoints;
                //    playerController.totalScore += bomberManger.bomberPoints;
                //    scoreGiven = true;
                //}
                //bomberManger.PlayerCounter();
                
                //if (!bomberInput.veryDead )
                //{
                //    //playerController.transform.position = reset;
                //    
                //    bomberManger.bomberPoints += 1;
                //    Debug.Log(bomberManger.playerCountBomber);
                //    bomberManger.PlayerCounter();

                //    //playerController.transform.position = reset;
                //    bomberInput.veryDead = true;
                //}



            }
        }

        //if (Physics.SphereCast(transform.position, 8f, Vector3.zero, out RaycastHit hit, Mathf.Infinity))
        //{

        //    if (hit.transform.TryGetComponent(out Barral barral))
        //    {
        //        //Debug.Log("found obj");
        //        barral.InteractB();
        //        DropChance();
        //    }
        //}
        //if (Physics.SphereCast(transform.position, 8f, Vector3.zero, out RaycastHit hit2, Mathf.Infinity))
        //{

        //    if (hit2.transform.TryGetComponent(out PlayerController playerController))
        //    {
        //        Debug.Log("playerDead");
        //        playerController.transform.position = new Vector3(0, 40, 0);
        //        playerController.transform.position = new Vector3(0, 40, 0);
        //        bomberManger.playerCountBomber--;
        //        bomberManger.bomberPoints += 1;
        //        Debug.Log(bomberManger.playerCountBomber);
        //        bomberManger.PlayerCounter();
        //    }
        //}
    }
    
    void Update()
    {

        //Debug.Log(bomberInput.canPlaceBomb);
        if (bomPlaced)
        {
            canPlaceBomb = false;
            //OnDrawGizmosSelected();
            //----
            //bomberInput.canPlaceBomb = false;
            targetTime -= Time.deltaTime;
        }


        //&& bomPlaced == true
        //if (targetTime >= -0.2f && targetTime <= 0.0f && bomPlaced == true)
        //{
        //    timerEnded();
        //    bomPlaced =false;
        //    bomberInput.canPlaceBomb = true;
        //}
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

        vectorZ = 1f;
        inputVector = new Vector2(10f, 0f);
        Explode();
        inputVector = new Vector2(0f, 10f);
        Explode();
        inputVector = new Vector2(-10f, 0f);
        Explode();
        inputVector = new Vector2(0f, -10f);
        Explode();

        inputVector = new Vector2(10f, -3f);
        Explode();
        inputVector = new Vector2(-3f, 10f);
        Explode();
        inputVector = new Vector2(-10f, 3f);
        Explode();
        inputVector = new Vector2(3f, -10f);
        Explode();

        inputVector = new Vector2(10f, 3f);
        Explode();
        inputVector = new Vector2(3f, 10f);
        Explode();
        inputVector = new Vector2(-10f, -3f);
        Explode();
        inputVector = new Vector2(-3f, -10f);
        Explode();

        //inputVector = new Vector2(8f, 2f);
        //Explode();
        //inputVector = new Vector2(2f, 8f);
        //Explode();
        //inputVector = new Vector2(-8f, -2f);
        //Explode();
        //inputVector = new Vector2(-2f, -8f);
        //Explode();

        //inputVector = new Vector2(12f, -2f);
        //Explode();
        //inputVector = new Vector2(-2f, 12f);
        //Explode();
        //inputVector = new Vector2(-12f, 2f);
        //Explode();
        //inputVector = new Vector2(2f, -12f);
        //Explode();



        //förstör markern och det som har spawnat på den

        if (bomberManger.bombUppgrade >uppgrade)
        {

            DestroyMarker();
        }
        //Destroy(gameObject);
        //DestroyMarker();
    }
}
