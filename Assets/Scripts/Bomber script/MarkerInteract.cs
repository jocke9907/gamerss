using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MarkerInteract : MonoBehaviour
{
    [SerializeField] private Transform bombPrefab;
    [SerializeField] private Transform bombSpawn;

    [SerializeField] private LayerMask barralLayerMask;
    [SerializeField] private LayerMask playerLayer;

    private Barral Barral;
    PlayerController playerController;
    
    //playerController = FindObjectOfType<BomberInput>();
    

    public float targetTime = 4.0f;
    Vector2 inputVector = new Vector2(1f, 0f);
    bool bomPlaced;
    public void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void Interact()
    {
        //Debug.Log("Interact marker!");
        Transform bombTransform  =Instantiate(bombPrefab, bombSpawn);
        bombTransform.localPosition = Vector3.zero;
        targetTime = 4.0f;
        bomPlaced = true;


    }
    

    void Explode()
    {
        
        float maxDistans = 12f;
       
       
        Vector3 explodeDir = new Vector3(inputVector.x, 0.1f, inputVector.y);
        

        if (Physics.Raycast(transform.position, explodeDir,  out RaycastHit raycastHit, maxDistans, barralLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out Barral barral))
            {
                //Debug.Log("found obj");
                barral.InteractB();
            }
            
        }

        if(Physics.Raycast(transform.position, explodeDir, out RaycastHit raycastHitPlayer, maxDistans, playerLayer))
        {
            Debug.Log("casting");
            if (raycastHitPlayer.transform.TryGetComponent(out PlayerController playerController))
            {
                Debug.Log("found Player");
                //Destroy(playerController);
                playerController.transform.position = new Vector3(0,40,0);
                BomberManger.playerCountBomber--;
                Debug.Log(BomberManger.playerCountBomber);
                BomberManger.PlayerCounter();
                
            }

        }
    }
    void Update()
    {
        
        if (bomPlaced == true)
        {
            targetTime -= Time.deltaTime;
        }


        //&& bomPlaced == true
        if (targetTime >= -0.2f && targetTime <= 0.0f && bomPlaced == true)
        {
            timerEnded();
            bomPlaced =false;
            
        }
    }
    
    void timerEnded()
    {
        
        Debug.Log("bomb explod");
        inputVector = new Vector2(1f, 0f);
        Explode();
        inputVector = new Vector2(0f, 1f);
        Explode();
        inputVector = new Vector2(-1f, 0f);
        Explode();
        inputVector = new Vector2(0f, -1f);
        Explode();
        Debug.Log(BomberManger.playerCountBomber);


        //förstör markern och det som har spawnat på den
        //Destroy(gameObject);
    }
}
