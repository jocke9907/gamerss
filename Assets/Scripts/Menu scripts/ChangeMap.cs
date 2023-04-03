using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMap : MonoBehaviour
{

    [SerializeField] private LayerMask playerLayer;

    [SerializeField] bool bomber;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
    [SerializeField] bool maze;
    [SerializeField]public  bool capture;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        
        
        
=======

        if (capture)
        {
            ChangeToMapCapture();
        }
        if (maze)
        {
            ChangeToMapMaze();
        }



>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
=======
    public void ChangeToMapCapture()
    {

        float maxDistans = 12f;
        Vector3 dir = new Vector3(0, 1f, 0);

        if (Physics.Raycast(transform.position, dir, out RaycastHit raycastHitPlayer, maxDistans, playerLayer))
        {

            if (raycastHitPlayer.transform.TryGetComponent(out PlayerController playerController))
            {
                
                Loader.Load(Loader.Scene.CaptureTheFlag);

            }

        }
    }
    public void ChangeToMapMaze()
    {

        float maxDistans = 12f;
        Vector3 dir = new Vector3(0, 1f, 0);

        if (Physics.Raycast(transform.position, dir, out RaycastHit raycastHitPlayer, maxDistans, playerLayer))
        {

            if (raycastHitPlayer.transform.TryGetComponent(out PlayerController playerController))
            {
                Loader.TheMazePlaying = true;
                Loader.Load(Loader.Scene.TheMaze);

            }

        }
    }
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

}
