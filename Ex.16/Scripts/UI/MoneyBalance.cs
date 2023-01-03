using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] TMP_Text _money;
    [SerializeField] Player _player;

    private void OnEnable()
    {
        _money.text = _player.Money.ToString();
        _player.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _money.text = money.ToString();
    }
}
