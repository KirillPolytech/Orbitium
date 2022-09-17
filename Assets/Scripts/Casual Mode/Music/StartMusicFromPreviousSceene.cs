using UnityEngine;

public class StartMusicFromPreviousSceene : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
