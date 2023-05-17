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
            player.GetComponent<PlayerController>().mapSelected = "Random Map";
            player.GetComponent<PlayerController>().mapSelectedInt = 0;
        }
        else if (GroundIsFalling)
        {
            player.GetComponent<PlayerController>().mapSelected = "Falling Ground";
            player.GetComponent<PlayerController>().mapSelectedInt = 1;
        }
        else if (MazeRunner)
        {
            player.GetComponent<PlayerController>().mapSelected = "Maze Runner";
            player.GetComponent<PlayerController>().mapSelectedInt = 2;
        }
        else if (WallClimber)
        {
            player.GetComponent<PlayerController>().mapSelected = "Wall Climber";
            player.GetComponent<PlayerController>().mapSelectedInt = 3;
        }
        else if (BomberMan)
        {
            player.GetComponent<PlayerController>().mapSelected = "Bomber Man";
            player.GetComponent<PlayerController>().mapSelectedInt = 4;
        }
        else if (CaptureFlag)
        {
            player.GetComponent<PlayerController>().mapSelected = "Capture Flag";
            player.GetComponent<PlayerController>().mapSelectedInt = 5;
        }
        else if (WheelSpinner)
        {
            player.GetComponent<PlayerController>().mapSelected = "Wheel Spinner";
            player.GetComponent<PlayerController>().mapSelectedInt = 6;
        }
        else if (LavaRun)
        {
            player.GetComponent<PlayerController>().mapSelected = "Lava Run";
            player.GetComponent<PlayerController>().mapSelectedInt = 7;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<PlayerController>().mapSelected = "";
        other.GetComponent<PlayerController>().mapSelectedInt =-1;
    }
}
