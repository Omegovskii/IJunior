using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private const string IsHurt = "isHurt";

    public Rigidbody2D Rigidbody => _rigidbody2D;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        _animator.SetTrigger(IsHurt);

        if (_health <= 0)
            Death();
    }

    private void Death()
    {
        gameObject.SetActive(false);
    }
}
