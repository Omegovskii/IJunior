using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    private float _maxHealth = 100f;

    public UnityAction ChangingHealth;
    public float Health => _health;

    public void TakeDamage(float damage)
    {
        if (_health > 0)
        {
            _health -= damage;
        }

        _health = Mathf.Clamp(_health, 0, _maxHealth);

        ChangingHealth?.Invoke();
    }

    public void UseFirstAidKit(float health)
    {
        if (_health < _maxHealth)
        {
            _health += health;
        }

        _health = Mathf.Clamp(_health, 0, _maxHealth);

        ChangingHealth?.Invoke();
    }
}