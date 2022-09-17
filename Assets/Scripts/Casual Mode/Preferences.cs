using UnityEngine;

public class Preferences : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 1;
    }
}
