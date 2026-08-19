using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;

public class MazeCreate : MonoBehaviour
{
    public NavMeshSurface groundSurface;
    private List<int[]> wallCheck = new List<int[]>();
    private int[] startPos = new int[2] { MazeData.startX, MazeData.startY };
    private int[] checkPos = new int[2];
    private int nextRandomPos = 0;
    void Awake()
    {
        CreateMaze();
        MezeRender mezeRender = GetComponent<MezeRender>();
        if (mezeRender != null)
        {
            mezeRender.mazeRender();
        }
        if (groundSurface != null)
        {
            groundSurface.BuildNavMesh();
        }
    }
    private void CreateMaze()
    {
        System.Array.Clear(MazeData.wall, 0, MazeData.wall.Length);
        MazeData.wall[startPos[0], startPos[1]] = true;
        checkPos[0] = startPos[0];
        checkPos[1] = startPos[1];
        {
            AddWall(checkPos[0] - 1, checkPos[1]);
            AddWall(checkPos[0] + 1, checkPos[1]);
            AddWall(checkPos[0], checkPos[1] - 1);
            AddWall(checkPos[0], checkPos[1] + 1);
        }
        while (true)
        {
            nextRandomPos = Random.Range(0, wallCheck.Count);
            checkPos[0] = wallCheck[nextRandomPos][0];
            checkPos[1] = wallCheck[nextRandomPos][1];
            if(checkPos[0]%2 == 0)
            {
                if(MazeData.wall[checkPos[0]-1, checkPos[1]] == false && MazeData.wall[checkPos[0]+1, checkPos[1]] == true)
                {
                    MazeData.wall[checkPos[0]-1, checkPos[1]] = true;
                    MazeData.wall[checkPos[0], checkPos[1]] = true;
                    AddWall(checkPos[0]-2, checkPos[1] );
                    AddWall(checkPos[0]-1, checkPos[1]+1 );
                    AddWall(checkPos[0]-1, checkPos[1]-1 );
                }
                else if(MazeData.wall[checkPos[0]-1, checkPos[1]] == true && MazeData.wall[checkPos[0]+1, checkPos[1]] == false)
                {
                    MazeData.wall[checkPos[0]+1, checkPos[1]] = true;
                    MazeData.wall[checkPos[0], checkPos[1]] = true;
                    AddWall(checkPos[0]+2, checkPos[1] );
                    AddWall(checkPos[0]+1, checkPos[1]-1 );
                    AddWall(checkPos[0]+1, checkPos[1]+1);
                }
            }
            else if(checkPos[1]%2 == 0)
            {
                if(MazeData.wall[checkPos[0], checkPos[1]-1] == false && MazeData.wall[checkPos[0], checkPos[1]+1] == true)
                {
                    MazeData.wall[checkPos[0], checkPos[1]-1] = true;
                    MazeData.wall[checkPos[0], checkPos[1]] = true;
                    AddWall(checkPos[0], checkPos[1]-2 );
                    AddWall(checkPos[0]+1, checkPos[1]-1 );
                    AddWall(checkPos[0]-1, checkPos[1]-1 );
                }
                else if(MazeData.wall[checkPos[0], checkPos[1]-1] == true && MazeData.wall[checkPos[0], checkPos[1]+1] == false)
                {
                    MazeData.wall[checkPos[0], checkPos[1]+1] = true;
                    MazeData.wall[checkPos[0], checkPos[1]] = true;
                    AddWall(checkPos[0], checkPos[1]+2 );
                    AddWall(checkPos[0]-1, checkPos[1]+1 );
                    AddWall(checkPos[0]+1, checkPos[1]+1 );
                }

            }
            wallCheck.RemoveAt(nextRandomPos);
            if(wallCheck.Count == 0)
            {
                break;
            }
        }
    }
    private void AddWall(int x, int y)
    {
        if (x <= 0 || x >= MazeData.width - 1 || y <= 0 || y >= MazeData.height - 1)
        {
            return;
        }
        wallCheck.Add(new int[2] { x, y });
    }
}
