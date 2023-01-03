using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _minHealth;
    [SerializeField] private int _maxHealth;  
    [SerializeField] private int _reward;
    [SerializeField] private TMP_Text _viewHealth;

    private int _health;

    public int Reward => _reward;
    public int Health => _health;
    public int MinHealth => _minHealth;
    public int MaxHealth => _maxHealth;

    public event UnityAction<int> HealthChanged;
    public event UnityAction<Enemy> Dying;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    public void Reset()
    {
        SetHealth();
    }

    public void IncreaseHealth()
    {
        int RandomHelth = Random.Range(10,25);
        _maxHealth += RandomHelth;
        _minHealth += RandomHelth;
    }

    private void Start()
    {
        SetHealth();
    }

    private void SetHealth()
    {
        _health = Random.Range(_minHealth, _maxHealth);
        _viewHealth.text = _health.ToString();
    }

    private void OnHealthChanged(int health)
    {
        _viewHealth.text = health.ToString();
    }

    private void OnEnable()
    {
        HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        HealthChanged -= OnHealthChanged;
    }

    private void Die()
    {
        Dying?.Invoke(this);
        Reset();
        gameObject.SetActive(false);       
    }
}
