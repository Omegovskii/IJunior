using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private float _delayBetweenShots;
    [SerializeField] private Weapon _weapon;

    private WaitForSeconds _delay; 

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
        _delay = new WaitForSeconds(_delayBetweenShots);
        CooldownChanged?.Invoke();
    }

    public void MakePurchase(int price)
    {
        Money -= price;
        MoneyChanged?.Invoke(Money);
    }

    public void Reset()
    {
        _mover.Reset();
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

    private void Start()
    {
        _delay = new WaitForSeconds(_delayBetweenShots);
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            _weapon.Shoot(_shootPoint);

            yield return _delay;
        }
    }
}
