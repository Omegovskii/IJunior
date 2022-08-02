using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform _spawn;
    [SerializeField] private Enemy _enemy;

    private Transform[] _spawnPoints;
    private WaitForSeconds _spawnTime;

    private void Start()
    {
        _spawnTime = new WaitForSeconds(2f);
        _spawnPoints = new Transform[_spawn.childCount];

        for (int i = 0; i < _spawn.childCount; i++)
        {
            _spawnPoints[i] = _spawn.GetChild(i);
        }

        StartCoroutine(CreateEnemies());
    }

    private IEnumerator CreateEnemies()
    {
        while (true)
        {
            Transform targetSpawn = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            var enemy = Instantiate(_enemy, targetSpawn.position, Quaternion.identity);

            yield return _spawnTime;
        }
    }
}
