using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToScene : MonoBehaviour
{
    [Tooltip("Name of the scene to load, must match Build Settings")]
    public string sceneName;

    void OnMouseDown() // if you click with mouse or VR pointer
    {
        SceneManager.LoadScene(sceneName);
    }

    // You can also call this manually from a button
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
