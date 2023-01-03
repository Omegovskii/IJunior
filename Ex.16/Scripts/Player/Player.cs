using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private float _delayBetweenShots;
    [SerializeField] private Weapon _weapon;

    private float _elapsedTimeBetweenShots;
    
    public int Money { get; private set; }
    public int Level { get; private set; }

    public event UnityAction<int> MoneyChanged;
    public event UnityAction CooldownChanged;
    public event UnityAction LevelChanged;
    public event UnityAction GameOver;

    public void Die()
    {
        GameOver?.Invoke();
    }

    public void DecreaseDelayBetweenShots(int value)
    {
        _delayBetweenShots -= (float)value / 100;
        CooldownChanged?.Invoke();
    }

    public void MakePurchase(int price)
    {
        Money -= price;
        MoneyChanged?.Invoke(Money);
    }

    public void Reset()
    {
        _mover.ResetPlayer();
    }

    public void LevelUp()
    {
        Level++;
        LevelChanged?.Invoke();
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    private void Update()
    {
        _elapsedTimeBetweenShots += Time.deltaTime;

        if (_elapsedTimeBetweenShots > _delayBetweenShots)
        {
            _weapon.Shoot(_shootPoint);
            _elapsedTimeBetweenShots = 0;
        } 
    }
}
