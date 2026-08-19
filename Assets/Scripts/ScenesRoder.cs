using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesRoder : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
