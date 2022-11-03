using UnityEngine;

public class FloorTrap : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;
    private int _currentPoint;

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            player.TakeDamage(_damage);
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentPoint].position, _speed * Time.deltaTime);

        if (transform.position == _waypoints[_currentPoint].position)
            _currentPoint = _currentPoint == 0 ? 1 : 0;
    }
}
