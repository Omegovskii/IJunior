using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    [SerializeField] protected Player _player;
    [SerializeField] protected PlayerMover _playerSpeed;
    [SerializeField] protected int _price;
    [SerializeField] protected Bullet _bullet;

    protected int _level = 0;

    public abstract void UpgradeAbility(int value);

    protected bool TryToUpgrade()
    {
        return _player.Money >= _price;
    }

    protected void RaisePrice()
    {
        _price += _price;
    }
}
