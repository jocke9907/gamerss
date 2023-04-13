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

    [SerializeField] bool pl1;
    [SerializeField] bool pl2;
    [SerializeField] bool pl3;
    [SerializeField] bool pl4;

    PlayerController playerController;
    BomberManger bomberManger;
   
    public void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        bomberManger = FindObjectOfType<BomberManger>();
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
        if(pl1)
        {
            Pl1();
        }
        if (pl2)
        {
            Pl2();
        }
        if (pl3)
        {
            Pl3();
        }
        if (pl4)
        {
            Pl4();
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
                    bomberManger.playerCountBomber = 1;
                }
                if (CreateGameUI.twoPlayer == true)
                {
                    bomberManger.playerCountBomber = 1;
                }
                if (CreateGameUI.threePlayer == true)
                {
                    bomberManger.playerCountBomber = 2;
                }
                if (CreateGameUI.fourPlayer == true)
                {
                    bomberManger.playerCountBomber = 3;
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
                Loader.wallClimberPlaying = false;
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
                Loader.wallClimberPlaying = true;
                Loader.TheMazePlaying = false;
                Loader.Load(Loader.Scene.SamScen);

            }

        }
    }

    public void Pl1()
    {
        float maxDistans = 12f;
        Vector3 dir = new Vector3(0, 1f, 0);

        if (Physics.Raycast(transform.position, dir, out RaycastHit raycastHitPlayer, maxDistans, playerLayer))
        {
            if (raycastHitPlayer.transform.TryGetComponent(out PlayerController playerController))
            {
                Debug.Log("pl1");
                playerController.playerOne = true;
            }
        }
    }
    public void Pl2()
    {
        float maxDistans = 12f;
        Vector3 dir = new Vector3(0, 1f, 0);

        if (Physics.Raycast(transform.position, dir, out RaycastHit raycastHitPlayer, maxDistans, playerLayer))
        {
            if (raycastHitPlayer.transform.TryGetComponent(out PlayerController playerController))
            {
                Debug.Log("pl2");
                playerController.playerTwo = true;
            }
        }
    }
    public void Pl3()
    {
        float maxDistans = 12f;
        Vector3 dir = new Vector3(0, 1f, 0);

        if (Physics.Raycast(transform.position, dir, out RaycastHit raycastHitPlayer, maxDistans, playerLayer))
        {
            if (raycastHitPlayer.transform.TryGetComponent(out PlayerController playerController))
            {
                Debug.Log("pl3");
                playerController.playerThree = true;
            }
        }
    }
    public void Pl4()
    {
        float maxDistans = 12f;
        Vector3 dir = new Vector3(0, 1f, 0);

        if (Physics.Raycast(transform.position, dir, out RaycastHit raycastHitPlayer, maxDistans, playerLayer))
        {
            if (raycastHitPlayer.transform.TryGetComponent(out PlayerController playerController))
            {
                Debug.Log("pl4");
                playerController.playerFour = true;
            }
        }
    }

}
