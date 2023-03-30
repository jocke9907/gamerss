using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMap : MonoBehaviour
{

    [SerializeField] private LayerMask playerLayer;

    [SerializeField] bool bomber;
    [SerializeField]public bool groundIsFalling = false;

    PlayerController playerController;

    public void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    public void Update()
    {
        if (bomber)
        {
            ChangeMapToBomber();
        }


        if (groundIsFalling)
        {
            ChangeMapToGroundFalling();
        }
        
        
        

    }
    public void ChangeMapToBomber()
    {

        float maxDistans = 12f;
        Vector3 dir = new Vector3(0, 1f, 0);

        if (Physics.Raycast(transform.position, dir, out RaycastHit raycastHitPlayer, maxDistans, playerLayer))
        {
            
            if (raycastHitPlayer.transform.TryGetComponent(out PlayerController playerController))
            {
                Loader.Load(Loader.Scene.BomberGame);
                Loader.bomberGamePlaying = true;

            }

        }
    }
    public void ChangeMapToGroundFalling()
    {

        float maxDistans = 12f;
        Vector3 dir = new Vector3(0, 1f, 0);

        if (Physics.Raycast(transform.position, dir, out RaycastHit raycastHitPlayer, maxDistans, playerLayer))
        {

            if (raycastHitPlayer.transform.TryGetComponent(out PlayerController playerController))
            {
                Debug.Log("now true");
                Loader.PlatformGamePlaying= true;
                Loader.Load(Loader.Scene.ViggesScene);

            }

        }
    }

}
