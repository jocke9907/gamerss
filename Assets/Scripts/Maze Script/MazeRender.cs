 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRender : MonoBehaviour
{
    [SerializeField] MazeGenerator mazeGenerator;
    [SerializeField] GameObject MazeCellPrefab;

    // the pysical size of the maze cells

    public float cellSize = 1f;

    private void Start()
    {
        MazeCell[,] maze = mazeGenerator.GetMaze(); // get the mazeGenerator scrip to create the maze

        for (int x = 0; x < mazeGenerator.mazeWith; x++) // loop through every cell in the maze
        {
            for (int y = 0; y < mazeGenerator.mazeHight; y++)
            {
              GameObject newCell = Instantiate (MazeCellPrefab, new Vector3((float)x * cellSize, 0f, (float)y * cellSize), Quaternion.identity, transform);

              MazeCellObject mazeCell = newCell.GetComponent<MazeCellObject>();
                 
                bool top = maze[x, y].topWall; // determine which wall need to be active
                bool left = maze[x, y].leftWall;

                bool right = false; // bottom and right are deactivated by defaul unless we are at the bottom or right edge of the maze
                bool bottom = false;    

                if(x == mazeGenerator.mazeWith -1) right = true;
                if (y == 0) bottom = true;  

                mazeCell.Init(top, bottom, right, left);    
            }
        }
    }
}
