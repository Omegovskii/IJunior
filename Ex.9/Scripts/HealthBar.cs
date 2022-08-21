using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Player _player;

    private Coroutine _activeCoroutine;

    private void OnEnable()
    {
        _player.ChangedHealth += OnChangingHealth;
    }

    private void OnDisable()
    {
        _player.ChangedHealth -= OnChangingHealth;
    }

    private void OnChangingHealth()
    {
        if(_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }

        _activeCoroutine = StartCoroutine(UpdateHealthBar(_player.Health));
    }

    private IEnumerator UpdateHealthBar(float target)
    {
        float speed = 20f;

        while (_healthBar.value != _player.Health)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, target, speed * Time.deltaTime);

            yield return null;
        }
    }
}