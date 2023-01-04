using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;

    private Vector3 _startPosition;

    public float Speed => _speed;

    public event UnityAction<float> SpeedChanged;

    private void Start()
    {
        _startPosition = _player.position;
    }

    public void MoveLeft()
    {
        _player.Translate(Vector3.left * _speed * Time.deltaTime);

        if (_player.position.x < _leftBorder.position.x)
            _player.position = _leftBorder.position;
    }

    public void MoveRight()
    {
        _player.Translate(Vector3.right * _speed * Time.deltaTime);

        if (_player.position.x > _rightBorder.position.x)
            _player.position = _rightBorder.position;
    }

    public void Reset()
    {
        _player.position = _startPosition;
    }

    public void IncreaseSpeed(float addition)
    {
        _speed += addition;
        SpeedChanged?.Invoke(_speed);
    }
}
