using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.ChangingHealth += OnChangingHealth;
    }

    private void OnDisable()
    {
        _player.ChangingHealth -= OnChangingHealth;
    }

    private void OnChangingHealth()
    {
        StartCoroutine(UpdateHealthBar());
    }

    private IEnumerator UpdateHealthBar()
    {
        float speed = 7f;

        while (_healthBar.value != _player.Health)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _player.Health, speed * Time.deltaTime);

            yield return null;
        }
    }
}