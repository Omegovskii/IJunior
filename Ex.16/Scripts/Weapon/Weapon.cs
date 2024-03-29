using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet Bullet;

    public abstract void Shoot(Transform shootPoint);
}
