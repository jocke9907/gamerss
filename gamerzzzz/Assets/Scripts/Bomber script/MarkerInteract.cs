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


    public void Interact()
    {
        Debug.Log("Interact marker!");
        Transform bombTransform  =Instantiate(bombPrefab, bombSpawn);
        bombTransform.localPosition = Vector3.zero;
        targetTime = 4.0f;
        
    }
    

    void Explode()
    {
        float maxDistans = 5f;
       
        Vector2 inputVector = new Vector2(2f,2f);
        Vector3 explodeDir = new Vector3(inputVector.x, 0f, inputVector.y);
        

        if (Physics.Raycast(transform.position, explodeDir,  out RaycastHit raycastHit, maxDistans, barralLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out MarkerInteract marker))
            {
                Debug.Log("found obj");
            }
            
        }
    }
    void Update()
    {


       
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
    }
    

    void timerEnded()
    {
        Debug.Log("bomb explod");

        //förstör markern och det som har spawnat på den
        //Destroy(gameObject);
    }
}
