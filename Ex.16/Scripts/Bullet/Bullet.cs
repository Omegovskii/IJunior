using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    public event UnityAction DamageChanged;

    public void IncreaseDamage(int value)
    {
        _damage += value;
        DamageChanged?.Invoke();
    }

    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}
