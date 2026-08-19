using UnityEngine;

public class MezeRender : MonoBehaviour
{
    public GameObject wallPrefab;
    private int spacing =2;
    public void mazeRender()
    {
        for(int i = 0; i < MazeData.width; i++)
        {
            for(int j = 0; j < MazeData.height; j++)
            {
                if(MazeData.wall[i,j] == false)
                {
                    Instantiate(wallPrefab, new Vector3(i * spacing, 0, j * spacing), Quaternion.identity, transform);
                }
            }
        }
    }
}
