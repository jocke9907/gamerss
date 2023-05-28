using TMPro;
using UnityEngine;

public class selectMap : MonoBehaviour
{

    //-----------Written by SAM-----------------

    // This script allows the player to choose what minigame they want to vote on next round.
    // And will also showcase descriptions for each map.
    // It does this by standing on one of the 8 pillars in the postlobby, each pillar having a trigger placed on them.
    // As long as they stand on a pillar, the script will assign two variables in each "playerController" script.

    // These two variables will later be used in the "MapVote" script, where it tells the script which minigame each player has chosen.
    // Should they leave a pillar, these two variables are reset until they stand upon a pillar again. The MapVote script 
    // also cannot start again until each player stands on a pillar again.

    // When a player stands on a specific pillar, a description of that minigame connected to said pillar will show up next to it,
    // until a player leaves the pillar again.









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
