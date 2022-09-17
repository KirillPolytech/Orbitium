using UnityEngine;

public class AddForceOnDrag : MonoBehaviour
{
    public float Force = 1f;
    public LineRenderer Line;

    private RaycastHit _spotHit;
    private Ray _cameraRay;
    private Vector3 _direction;
    private Vector3 _hitCoordinates;
    private const float _maxRayDistance = 500f;
    private bool _isHoldingLeftButtonDown = false;
    private Vector2 _mousePosition;
    private Player _player;
    private GameObject _playerGameObject;
    private void Start()
    {
        _playerGameObject = GameObject.FindGameObjectWithTag("Player");
        _player = _playerGameObject.GetComponent<Player>();

        Line.useWorldSpace = true;
        Line.startWidth = 1f;
        Line.endWidth = 0.3f;
    }
    private void Update()
    {
        _isHoldingLeftButtonDown = Input.GetButton("Fire1");
        _mousePosition = Input.mousePosition;
    }
    private void FixedUpdate()
    {
        _cameraRay = Camera.main.ScreenPointToRay(_mousePosition);

        if (Physics.Raycast(_cameraRay, out _spotHit, _maxRayDistance))
        {
            if (!_spotHit.collider.CompareTag("Player") && _isHoldingLeftButtonDown && _player.GetStamina() > 0f)
            {
                _direction = _spotHit.point - _playerGameObject.transform.position;
                _direction = new(_direction.x, 0, _direction.z);

                _playerGameObject.GetComponent<Rigidbody>().AddForce(_direction * Force, ForceMode.Impulse);

                _player.WasteStamina();
                
                SetLinePosition();
            }
        }
        if (!_isHoldingLeftButtonDown)
        {
            SetLinePositionToZero();
        }

        Debug.DrawLine(_cameraRay.origin, _spotHit.point, Color.red);
        Debug.DrawLine(_playerGameObject.transform.position, _spotHit.point, Color.blue);
    }
    void SetLinePosition()
    {
        _hitCoordinates = new(_spotHit.point.x, 0, _spotHit.point.z);
        Line.SetPosition(0, _playerGameObject.transform.position);
        Line.SetPosition(1, _hitCoordinates);
    }
    public void SetLinePositionToZero()
    {
        Line.SetPosition(0, Vector3.zero);
        Line.SetPosition(1, Vector3.zero);
    }
}
/*
1 - Проверить, держим ли мы кнопку.
2 - Проверить, убрали ли мы мышку с игрока.
3 - Создать вектор в направлении точки удара с поверхностью.
4 - Добавить силу к игроку в направлении этого вектора.
*/

// IsHittedPlayer = (Physics.Raycast(_cameraRay, out _playerHit, _maxRayDistance) && _playerHit.collider.CompareTag("Player"));