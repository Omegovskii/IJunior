using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageUpgrade : Upgrade
{
    [SerializeField] private TMP_Text _damage;
    [SerializeField] private TMP_Text _damageTag;

    public override void UpgradeAbility(int value)
    {
        if (TryToUpgrade())
        {
            _bullet.IncreaseDamage(value);
            _player.MakePurchase(_price);
            RaisePrice();
            _damageTag.text = _price.ToString();
        }
    }

    private void Start()
    {
        _damage.text = _level.ToString(); ;
        _damageTag.text = _price.ToString();
    }

    private void OnEnable()
    {
        _bullet.DamageChanged += OnDamageChanged;
    }

    private void OnDisable()
    {
        _bullet.DamageChanged -= OnDamageChanged;
    }

    private void OnDamageChanged()
    {
        _player.LevelUp();
        _level++;
        _damage.text = _level.ToString();
    }
}
