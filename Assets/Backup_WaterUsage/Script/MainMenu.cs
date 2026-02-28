using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Load the Water Wastage Scene
    public void StartGame()
    {
        SceneManager.LoadScene("WaterWastageScene");
        // Make sure "WaterWastageScene" is the exact name of your main scene
    }

    // Optional: Quit Button
    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }
}
