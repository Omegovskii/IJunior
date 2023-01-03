using UnityEngine;
using TMPro;

public class CooldownUpgrade : Upgrade
{
    [SerializeField] private TMP_Text _cooldown;
    [SerializeField] private TMP_Text _cooldownTag;

    public override void UpgradeAbility(int value)
    {
        if (TryToUpgrade())
        {
            _player.DecreaseDelayBetweenShots(value);
            _player.MakePurchase(_price);
            RaisePrice();
            _cooldownTag.text = _price.ToString();
        }
    }

    private void Start()
    {
        _cooldown.text = _level.ToString();
        _cooldownTag.text = _price.ToString();
    }

    private void OnEnable()
    {
        _player.CooldownChanged += OnCooldownChanged;
    }

    private void OnDisable()
    {
        _player.CooldownChanged -= OnCooldownChanged;
    }

    private void OnCooldownChanged()
    {
        _player.LevelUp();
        _level++;
        _cooldown.text = _level.ToString();
    }
}

