using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [Range(5, 100)]
    public int mazeWith = 5, mazeHight = 5; //dimension of the maze
    public int startX, startY; // where the maze start
    MazeCell[,] maze;

    Vector2Int currentCell; // the mazeCell we currently looking at

    public MazeCell[,] GetMaze()
    {
        maze = new MazeCell[mazeWith, mazeHight];

        for (int x = 0; x < mazeWith; x++)
        {
            for (int y = 0; y < mazeHight; y++)
            {
                maze[x, y] = new MazeCell(x, y);
            }
        }

        CarvePath(startX, startY); 
        return maze;

    }

    List<Direction> directions = new List<Direction> { Direction.Up, Direction.Down, Direction.Left, Direction.Right };

    List<Direction> GetRandomDirections() 
    {
        List<Direction> dir = new List<Direction>(directions); //copy of the first

        List<Direction> rndDir = new List<Direction>(); // list to put the randomised directions into

        while (dir.Count > 0) // loops, and picks a random one from the dir list and puts it into the rndDir and then removes it from the dir list. Continues until the list is empty
        {
            int rnd = Random.Range(0, dir.Count);
            rndDir.Add(dir[rnd]);
            dir.RemoveAt(rnd);
        }

        return rndDir; // When we got all four directions in a random order, return the queue
    }

    bool IsCellValid(int x, int y) // if the cell is outside the map or already been visited, then not valid
    {
        if (x < 0 || y < 0 || x > mazeWith - 1 || y > mazeHight - 1 || maze[x, y].visited) return false;
        else return true;
    }

    Vector2Int CheckNeighbour() 
    {
        List<Direction> rndDir = GetRandomDirections();

        for (int i = 0; i < rndDir.Count; i++)
        {
            Vector2Int neighbour = currentCell; // set the coordinates to current cell for now

            switch (rndDir[i]) // modifyt neighbour coordinates based in therandom directions we are trying
            {
                case Direction.Up:
                    neighbour.y++;
                    break;
                case Direction.Down:
                    neighbour.y--;
                    break;
                case Direction.Right:
                    neighbour.x++;
                    break;
                case Direction.Left:
                    neighbour.x--;
                    break;
            }

            if (IsCellValid(neighbour.x, neighbour.y)) return neighbour; // if the neighbour is valid we return that neighbour, if nor try again  
        }

        return currentCell;
    }

    void BreakWalls(Vector2Int primaryCell, Vector2Int secondaryCell) // checks which walls need to be broken down 
    {
        if (primaryCell.x > secondaryCell.x) // primary cell left wall
        {
            maze[primaryCell.x, primaryCell.y].leftWall = false;
        }
        else if (primaryCell.x < secondaryCell.x) // secondary cell left wall
        {
            maze[secondaryCell.x, secondaryCell.y].leftWall = false;
        }
        else if (primaryCell.y < secondaryCell.y) // primary  cell top wall
        {
            maze[primaryCell.x, primaryCell.y].topWall = false;
        }
        else if (primaryCell.y > secondaryCell.y) // secondary cell top wall
        {
            maze[secondaryCell.x, secondaryCell.y].topWall = false;
        }
    }

    void CarvePath(int x, int y) // starting at x, y passed in, carves a path through the maze untiol it comes to a dead end. (dead end is when a cell do not have any valid naighbours)
    {
        if (x < 0 || y < 0 || x > mazeWith - 1 || y > mazeWith - 1) // makes sure the start pos is within the boundaries of the map, if not set defaul to 0,0
        {
            x = y = 0;
        }


        currentCell = new Vector2Int(x, y); // set current cell to starting pos

        List<Vector2Int> path = new List<Vector2Int>(); // list to keep track of current path

        bool deadEnd = false;

        while (!deadEnd) // loop until we come to dead end
        {
            Vector2Int nextCell = CheckNeighbour(); // get next cel and try

            if (nextCell == currentCell)  
            {
                for (int i = path.Count - 1; i >= 0; i--)
                {
                    currentCell = path[i]; // set currentcell to the next step bakcon our path
                    path.RemoveAt(i); //remove that step from path
                    nextCell = CheckNeighbour(); //check that cell to see if there are any our valid neighbours

                    if (nextCell != currentCell) break;
                }

                if(nextCell == currentCell) // if theres no valid neighbours we break out of the loop
                {
                    deadEnd = true;
                }

            }
            else // set wall flags on these cells, and let us know we have visited and can move on, and the current cell will be valid neigbour we found
            {   // and the we add this to our path
                BreakWalls(currentCell, nextCell);
                maze[currentCell.x, currentCell.y].visited = true;
                currentCell = nextCell;
                path.Add(currentCell);
            }
        }
    }

}

public enum Direction 
{
    Up,
    Down,
    Left,
    Right
}

public class MazeCell //Holds the data for each individual mazeCell
{
    public bool visited;
    public int x, y;

    public bool topWall;
    public bool leftWall;
    public Vector2Int position
    {
        get
        {
            return new Vector2Int(x, y);
        }

    }

    public MazeCell(int x, int y)
    {
        this.x = x; // the maze grid
        this.y = y;

        visited = false; // if the algorithhm has visited this cell or not
        topWall = leftWall = true;
    }
}
