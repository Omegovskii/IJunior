using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _delay;
    [SerializeField] private Player _player;
    [SerializeField] private ObjectPool _pool;

    private float _timePassed;

    private void Start()
    {
        _pool.Initialize(_enemies);
    }

    private void Update()
    {
        _timePassed += Time.deltaTime;

        if(_timePassed > _delay)
            if(_pool.TryGetObject(out Enemy enemy))
            {
                _timePassed = 0;
                SetEnemy(enemy, _spawnPoints[Random.Range(0, _spawnPoints.Length)].position);
                enemy.Dying += OnEnemyDying;
            }     
    }

    private void OnEnable()
    {
        _player.LevelChanged += OnLevelChanged;
    }

    private void OnDisable()
    {
        _player.LevelChanged -= OnLevelChanged;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _player.AddMoney(enemy.Reward);
    }

    private void SetEnemy(Enemy enemy, Vector3 spawnPoint)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private void OnLevelChanged()
    {
        _delay -= 0.2f;

        foreach (var enemy in _enemies)
            enemy.IncreaseHealth();
    }
}
