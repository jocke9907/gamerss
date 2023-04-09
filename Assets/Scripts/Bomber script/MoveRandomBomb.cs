using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomBomb : MonoBehaviour
{
    [SerializeField] private LayerMask randomBombLayerMask;


    void Start()
    {
        
    }

    void Update()
    {
        // sätt dit timer
        // movment

    }

    void CastRay()
    {
        
        float maxDistans = 200f ;


        Vector3 placeDir = new Vector3(1, 0, 0);


        if (Physics.Raycast(transform.position, placeDir, out RaycastHit raycastHit, maxDistans, randomBombLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out Barral barral))
            {
               
            }

        }
        transform.position = new Vector3(27, 1.37f, 49);
    }
}
