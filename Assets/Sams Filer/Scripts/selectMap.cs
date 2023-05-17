using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class selectMap : MonoBehaviour
{
    public bool RandomMap;
    public bool GroundIsFalling;
    public bool MazeRunner;
    public bool WallClimber;
    public bool BomberMan;
    public bool CaptureFlag;
    public bool WheelSpinner;
    public bool LavaRun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider player)
    {
        if (RandomMap)
        {
            player.GetComponent<PlayerController>().mapSelected = "RandomMap";
            player.GetComponent<PlayerController>().mapSelectedInt = 0;
        }
        else if (GroundIsFalling)
        {
            player.GetComponent<PlayerController>().mapSelected = "GroundIsFalling";
            player.GetComponent<PlayerController>().mapSelectedInt = 1;
        }
        else if (MazeRunner)
        {
            player.GetComponent<PlayerController>().mapSelected = "MazeRunner";
            player.GetComponent<PlayerController>().mapSelectedInt = 2;
        }
        else if (WallClimber)
        {
            player.GetComponent<PlayerController>().mapSelected = "WallClimber";
            player.GetComponent<PlayerController>().mapSelectedInt = 3;
        }
        else if (BomberMan)
        {
            player.GetComponent<PlayerController>().mapSelected = "BomberMan";
            player.GetComponent<PlayerController>().mapSelectedInt = 4;
        }
        else if (CaptureFlag)
        {
            player.GetComponent<PlayerController>().mapSelected = "CaptureFlag";
            player.GetComponent<PlayerController>().mapSelectedInt = 5;
        }
        else if (WheelSpinner)
        {
            player.GetComponent<PlayerController>().mapSelected = "WheelSpinner";
            player.GetComponent<PlayerController>().mapSelectedInt = 6;
        }
        else if (LavaRun)
        {
            player.GetComponent<PlayerController>().mapSelected = "LavaRun";
            player.GetComponent<PlayerController>().mapSelectedInt = 7;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<PlayerController>().mapSelected = "";
        other.GetComponent<PlayerController>().mapSelectedInt =-1;
    }
}
