using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] Enemy _enemy;
    [SerializeField] private float _force;
    [SerializeField] private float _minReboundAngle;
    [SerializeField] private float _maxReboundAngle;
    [SerializeField] private float _reboundHeight;

    private float _reboundAngle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _reboundAngle = Random.Range(_minReboundAngle, _maxReboundAngle);

        if (collision.gameObject.TryGetComponent(out Wall wall))
            _enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(_reboundAngle, _reboundHeight) * _force, ForceMode2D.Force);
    }
}
