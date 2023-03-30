 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRender : MonoBehaviour
{
    [SerializeField] MazeGenerator mazeGenerator;
    [SerializeField] GameObject MazeCellPrefab;

    public float cellSize = 1f;

    private void Start()
    {
        MazeCell[,] maze = mazeGenerator.GetMaze();

        for (int x = 0; x < mazeGenerator.mazeWith; x++)
        {
            for (int y = 0; y < mazeGenerator.mazeHight; y++)
            {
              GameObject newCell = Instantiate (MazeCellPrefab, new Vector3((float)x * cellSize, 0f, (float)y * cellSize), Quaternion.identity, transform);

              MazeCellObject mazeCell = newCell.GetComponent<MazeCellObject>();
                 
                bool top = maze[x, y].topWall;
                bool left = maze[x, y].leftWall;

                bool right = false;
                bool bottom = false;    

                if(x == mazeGenerator.mazeWith -1) right = true;
                if (y == 0) bottom = true;  

                mazeCell.Init(top, bottom, right, left);    
            }
        }
    }
}
