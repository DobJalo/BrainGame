using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load next scene (make sure it's added to Build Settings)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenSettings()
    {
<<<<<<< HEAD:Assets/Scenes/Main menu.cs
        Debug.Log("Settings menu opened"); // Replace with your own logic
=======
        SceneManager.LoadScene("Settings");
>>>>>>> 7a4532a0dcdc895e79667f2f5c2bbc175be1da39:Assets/Scripts/Main menu.cs
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
