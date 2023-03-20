using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerInteract : MonoBehaviour
{
    [SerializeField] private Transform bombPrefab;
    [SerializeField] private Transform bombSpawn;

    [SerializeField] private LayerMask barralLayerMask;
    private Barral Barral;

    public float targetTime = 20.0f;
    Vector2 inputVector = new Vector2(1f, 0f);

    public void Interact()
    {
        Debug.Log("Interact marker!");
        Transform bombTransform  =Instantiate(bombPrefab, bombSpawn);
        bombTransform.localPosition = Vector3.zero;
        targetTime = 4.0f;
        
    }
    public void GameStart()
    {

    }

    void Explode()
    {
        float maxDistans = 10f;
       
       
        Vector3 explodeDir = new Vector3(inputVector.x, 0f, inputVector.y);
        

        if (Physics.Raycast(transform.position, explodeDir,  out RaycastHit raycastHit, maxDistans, barralLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out Barral barral))
            {
                Debug.Log("found obj");
                barral.InteractB();
            }
            
        }
    }
    void Update()
    {       
        targetTime -= Time.deltaTime;

        if (targetTime >= -1f &&targetTime <= 0.0f)
        {
            timerEnded();
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
        //förstör markern och det som har spawnat på den
        //Destroy(gameObject);
    }
}
