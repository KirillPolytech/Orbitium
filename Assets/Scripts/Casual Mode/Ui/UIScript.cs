using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI FPS;

    public TextMeshProUGUI CollectablesText;

    public Image StaminaImage;

    public GameObject WinCanvas;
    public GameObject GameOverCanvas;
    public GameObject ExitCanvas;

    public Toggle GodMode;

    private GameObject _playerGameObject;
    private AddForceOnDrag _addForceOnDrag;
    private Player _player;

    private float deltaTime;
    private void Start()
    {
        _playerGameObject = GameObject.FindGameObjectWithTag("Player");
        _addForceOnDrag = _playerGameObject.GetComponent<AddForceOnDrag>();
        _player = _playerGameObject.GetComponent<Player>();

        // After Restart Settings.
        WinCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
        //
    }
    private void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        FPS.text = "FPS: " + (int)(1.0f / deltaTime);

        ExitScreen();

        _player.SetGodMode(GodMode.isOn);
    }
    private void FixedUpdate()
    {
        DeadScreen();
        WinScreen();

        CollectablesCounter();

        StaminaImage.fillAmount = _player.GetStamina() / 100;
    }
    void DeadScreen()
    {
        if ( _player.IsDeadStatement() && !_player.IsWinStatement())
        {
            GameOverCanvas.SetActive(true);

            _addForceOnDrag.SetLinePositionToZero();
            _addForceOnDrag.enabled = false;
        }
    }
    void WinScreen()
    {
        if (_player.IsWinStatement() && !_player.IsDeadStatement() )
        {
            WinCanvas.SetActive(true);

            _addForceOnDrag.SetLinePositionToZero();
            _addForceOnDrag.enabled = false;
        }
    }
    void ExitScreen()
    {       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TimeScaleToToZero();
            ExitCanvas.SetActive(true);
        }
    }
    public void TimeScaleToToZero()
    {
        Time.timeScale = 0;
    }
    public void TimeScaleToToNormal()
    {
        Time.timeScale = 1;
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    void CollectablesCounter()
    {
        CollectablesText.text = "Collected: " + _player.GetCollectables() + " / " + CollectablesManager.GetCountOfCollectables();
    }
}
// Camera.main.GetComponent<CameraTracking>().Line.enabled = false;