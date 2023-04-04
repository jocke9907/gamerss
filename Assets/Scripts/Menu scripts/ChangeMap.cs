using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMap : MonoBehaviour
{

    [SerializeField] private LayerMask playerLayer;


    [SerializeField] bool wallClimber;
    [SerializeField] bool maze;
    [SerializeField] bool bomber;
    [SerializeField]public  bool capture;
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

        if (capture)
        {
            ChangeToMapCapture();
        }
        if (maze)
        {
            ChangeToMapMaze();
        }
        if (wallClimber)
        {
            ChangeToMapWallClimber();
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
                if(CreateGameUI.onePlayer == true)
                {
                    BomberManger.playerCountBomber = 1;
                }
                if (CreateGameUI.twoPlayer == true)
                {
                    BomberManger.playerCountBomber = 1;
                }
                if (CreateGameUI.threePlayer == true)
                {
                    BomberManger.playerCountBomber = 2;
                }
                if (CreateGameUI.fourPlayer == true)
                {
                    BomberManger.playerCountBomber = 3;
                }

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
    public void ChangeToMapWallClimber()
    {

        float maxDistans = 12f;
        Vector3 dir = new Vector3(0, 1f, 0);

        if (Physics.Raycast(transform.position, dir, out RaycastHit raycastHitPlayer, maxDistans, playerLayer))
        {

            if (raycastHitPlayer.transform.TryGetComponent(out PlayerController playerController))
            {
                Loader.TheMazePlaying = true;
                Loader.Load(Loader.Scene.SamScen);

            }

        }
    }

}
