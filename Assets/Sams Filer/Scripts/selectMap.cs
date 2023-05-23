using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
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

    [SerializeField] TMP_Text groundFallingText;
    [SerializeField] TMP_Text mazeRunnerText;
    [SerializeField] TMP_Text wallClimberText;
    [SerializeField] TMP_Text bomberManText;
    [SerializeField] TMP_Text captureFlagText;
    [SerializeField] TMP_Text wheelSpinner;
    [SerializeField] TMP_Text lavaRunText;
    // Start is called before the first frame update
    void Start()
    {
        groundFallingText.enabled = false;
        mazeRunnerText.enabled = false;
        wallClimberText.enabled = false;
        bomberManText.enabled = false;
        captureFlagText.enabled = false;
        wheelSpinner.enabled = false;
        lavaRunText.enabled = false;
    }

    private void OnTriggerStay(Collider player)
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
            groundFallingText.enabled = true;
        }
        else if (MazeRunner)
        {
            player.GetComponent<PlayerController>().mapSelected = "Maze Runner";
            player.GetComponent<PlayerController>().mapSelectedInt = 2;
            mazeRunnerText.enabled = true;
        }
        else if (WallClimber)
        {
            player.GetComponent<PlayerController>().mapSelected = "Wall Climber";
            player.GetComponent<PlayerController>().mapSelectedInt = 3;
            wallClimberText.enabled = true;
        }
        else if (BomberMan)
        {
            player.GetComponent<PlayerController>().mapSelected = "Bomber Man";
            player.GetComponent<PlayerController>().mapSelectedInt = 4;
            bomberManText.enabled = true;
        }
        else if (CaptureFlag)
        {
            player.GetComponent<PlayerController>().mapSelected = "Capture Flag";
            player.GetComponent<PlayerController>().mapSelectedInt = 5;
            captureFlagText.enabled = true;
        }
        else if (WheelSpinner)
        {
            player.GetComponent<PlayerController>().mapSelected = "Wheel Spinner";
            player.GetComponent<PlayerController>().mapSelectedInt = 6;
            wheelSpinner.enabled = true;
        }
        else if (LavaRun)
        {
            player.GetComponent<PlayerController>().mapSelected = "Lava Run";
            player.GetComponent<PlayerController>().mapSelectedInt = 7;
            lavaRunText.enabled = true;
        }

    }
    private void OnTriggerExit(Collider player)
    {
        player.GetComponent<PlayerController>().mapSelected = "";
        player.GetComponent<PlayerController>().mapSelectedInt = -1;

        if (GroundIsFalling)
        {
            groundFallingText.enabled = false;
        }
        else if (MazeRunner)
        {
            mazeRunnerText.enabled = false;
        }
        else if (WallClimber)
        {
            wallClimberText.enabled = false;
        }
        else if (BomberMan)
        {
            bomberManText.enabled = false;
        }
        else if (CaptureFlag)
        {
            captureFlagText.enabled = false;
        }
        else if (WheelSpinner)
        {
            wheelSpinner.enabled = false;
        }
        else if (LavaRun)
        {
            lavaRunText.enabled = false;
        }
    }
}
