using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<Enemy> _pool = new List<Enemy>();

    public void Initialize(Enemy[] prefabs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Enemy spawned = Instantiate(prefabs[Random.Range(0, prefabs.Length)], _container.transform);
            spawned.gameObject.SetActive(false);
            _pool.Add(spawned);
        }
    }

    public bool TryGetObject(out Enemy result)
    {
        List<Enemy> enemies = new List<Enemy>();

        enemies = _pool.Where(item => item.gameObject.activeSelf == false).ToList();
        
        if (enemies.Count <= 0)
            result = null;
        else
            result = enemies[Random.Range(0, enemies.Count)];

        return result != null;
    }

    public void Reset()
    {
        foreach (var item in _pool)
        {
            item.gameObject.SetActive(false);
            item.Reset();
        }
    }
}
