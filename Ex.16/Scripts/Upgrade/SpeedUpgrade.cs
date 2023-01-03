using UnityEngine;
using TMPro;

public class SpeedUpgrade : Upgrade
{
    [SerializeField] private TMP_Text _speed;
    [SerializeField] private TMP_Text _priceTag;

    public override void UpgradeAbility(int value)
    {
        if (TryToUpgrade())
        {
            _playerSpeed.IncreaseSpeed(value);
            _player.MakePurchase(_price);
            RaisePrice();
            _priceTag.text = _price.ToString();
        }
    }

    private void Start()
    {
        _speed.text = _level.ToString();
        _priceTag.text = _price.ToString();
    }

    private void OnEnable()
    {
        _playerSpeed.SpeedChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _playerSpeed.SpeedChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(float speed)
    {
        _player.LevelUp();
        _level++;
        _speed.text = _level.ToString();
    }
}
