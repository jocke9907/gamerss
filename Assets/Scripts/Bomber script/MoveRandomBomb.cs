using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveRandomBomb : MonoBehaviour
{
    [SerializeField] private LayerMask randomBombLayerMask;
    [SerializeField] private LayerMask markerLayerMask;
    MarkerInteract marker;

    public float targetTime2 = 60.0f;
    float x = 0;
    float y = 0;
    void Start()
    {
        targetTime2 = 1.0f;
    }

    void Update()
    {
        // s�tt dit timer
        // movment
        targetTime2 -= Time.deltaTime;
        if (targetTime2 < 0 )
        {
            for( int i = 0; i < 12; i++ )
            {
                CastRay();
            }                      
            x += 4;
            y = 0;
            transform.position = new Vector3(-27+ y, 1.37f, -49 + x);
            
            targetTime2 = 12f;
          
            
        }
        
    }

   

    void CastRay()
    {
        
        y += 8;
        float maxDistans = 10f ;
        //float maxDistans = 12f;


        Vector3 placeDir = new Vector3(10, 0f, 0);

        if (marker != null)
        {

            marker.RandomBombs();
        }
        if (Physics.Raycast(transform.position, placeDir, out RaycastHit raycastHit, maxDistans, markerLayerMask))
        {
           // Debug.Log("fire");
            //if (raycastHit.transform.TryGetComponent(out RandomBomb randomBomb))
            //{
            //    Debug.Log("hit");
            //    randomBomb.DropBombs();
            //}
            if (raycastHit.transform.TryGetComponent(out MarkerInteract marker))
            {
                //Debug.Log("hit");
                marker.RandomBombs();
                
            }
            

        }
        transform.position = new Vector3(-27 + y, 1.37f, -49 + x);


    }
}
