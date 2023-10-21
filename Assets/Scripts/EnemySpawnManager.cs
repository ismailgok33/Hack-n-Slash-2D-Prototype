using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private List<Transform> spawnPositionList;
    
    [Header("Spawn Settings")]
    [SerializeField] private float nextWaveSpawnTimer = 10f;
    [SerializeField] private float enemySpawnDelay = 2f;
    [SerializeField] private int enemySpawnCount = 1;
    private int waveNumber = 1;
    
    private void Update()
    {
        nextWaveSpawnTimer -= Time.deltaTime;
        if (nextWaveSpawnTimer < 0f)
        {
            StartCoroutine(SpawnEnemyCoroutine(enemySpawnCount * waveNumber, enemySpawnDelay));
            nextWaveSpawnTimer = 10f;
            waveNumber++;
        }
    }

    private Enemy CreateEnemy(Vector2 position)
    {
        var enemyTransform = Instantiate(enemyPrefab, position, Quaternion.identity);

        return enemyTransform.GetComponent<Enemy>();
    }

    private IEnumerator SpawnEnemyCoroutine(int count, float delay)
    {
        for (var i = 0; i < count; i++)
        {
            foreach (var spawnPosition in spawnPositionList)
            {
                CreateEnemy(spawnPosition.position);
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
