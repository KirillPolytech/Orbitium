using UnityEngine;
using UnityEngine.SceneManagement;
public class NextButtons : MonoBehaviour
{
    public void NextButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }
}
//Collectables = 0;
//WinCollectables = 4;
// Time.timeScale = 1;