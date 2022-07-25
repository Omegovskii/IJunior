using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingEnemies : MonoBehaviour
{
    [SerializeField] private Transform _spawn;
    [SerializeField] private Transform _portalPosition;
    [SerializeField] private GameObject _enemy;

    private Transform[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = new Transform[_spawn.childCount];

        for (int i = 0; i < _spawn.childCount; i++)
        {
            _spawnPoints[i] = _spawn.GetChild(i);
        }

        StartCoroutine(CreateEnemies());
    }

    private IEnumerator CreateEnemies()
    {
	float spawnTime = 2f;	

        while (true)
        {
            Transform targetSpawn = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            GameObject enemy = Instantiate(_enemy, targetSpawn.position, Quaternion.identity);

            StartCoroutine(MovementEnemy(enemy));

            yield return new WaitForSeconds(spawnTime);
        }
    }

    private IEnumerator MovementEnemy(GameObject enemy)
    {
        float minSpeed = 5;
        float maxSpeed = 10;
        float speed = Random.Range(minSpeed, maxSpeed);

        while (enemy.transform.position != _portalPosition.position)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, _portalPosition.position, Time.deltaTime * speed);
            yield return new WaitForFixedUpdate();
        }

        Destroy(enemy);

        yield break;
    }
}
