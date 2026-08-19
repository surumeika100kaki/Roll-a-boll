using UnityEngine;

public static class MazeData
{
    public static int width = 33;
    public static int height = 33;
    public static int startX = MazeData.width/2 +1;
    public static int startY = MazeData.height/2 +1;
    public static bool[,] wall = new bool[MazeData.width, MazeData.height];
}
