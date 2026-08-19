using UnityEngine;

public class ScreItemCreate : MonoBehaviour
{
    public GameObject[] itemPrefab;
    private float CreateTime = 5f;
    void Update()
    {
        if(CreateTime <= 0)
        {
            float x = Random.Range(0, MazeData.width);
            float z = Random.Range(0, MazeData.height);
            if(MazeData.wall[(int)x,(int)z] == true)
            {
                int randomIndex = Random.Range(0, itemPrefab.Length);
                Instantiate(itemPrefab[randomIndex], new Vector3(x * 2, 0.5f, z * 2), Quaternion.identity);
                CreateTime = 5f;
            }
        }
        else
        {
            CreateTime -= Time.deltaTime;
        }
    }
}
