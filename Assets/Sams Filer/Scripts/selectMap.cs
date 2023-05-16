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
        }
        else if (GroundIsFalling)
        {
            player.GetComponent<PlayerController>().mapSelected = "GroundIsFalling";
        }
        else if (MazeRunner)
        {
            player.GetComponent<PlayerController>().mapSelected = "MazeRunner";
        }
        else if (WallClimber)
        {
            player.GetComponent<PlayerController>().mapSelected = "WallClimber";
        }
        else if (BomberMan)
        {
            player.GetComponent<PlayerController>().mapSelected = "BomberMan";
        }
        else if (CaptureFlag)
        {
            player.GetComponent<PlayerController>().mapSelected = "CaptureFlag";
        }
        else if (WheelSpinner)
        {
            player.GetComponent<PlayerController>().mapSelected = "WheelSpinner";
        }
        else if (LavaRun)
        {
            player.GetComponent<PlayerController>().mapSelected = "LavaRun";
        }

    }
    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<PlayerController>().mapSelected = "";
    }
}
