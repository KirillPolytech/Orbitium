using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");

    }
    public void LoadSurvivalScene()
    {
        SceneManager.LoadScene("Survival");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
