using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This function will be called by the Start button
    public void StartGame()
    {
        // Change "GameScene" to the name of your gameplay scene
        SceneManager.LoadScene("PollutionScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }
}
