using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        _animator.SetTrigger("isHurt");

        if (_health <= 0)
            Death();
    }

    private void Death()
    {
        gameObject.SetActive(false);
    }
}
