using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Collider2D spawnArea;
    [SerializeField] float spawnDelay = 1f;

    private float elapsed;

    void Update()
    {
        elapsed += Time.deltaTime;

        if (elapsed >= spawnDelay)
        {
            SpawnEnemy();
            elapsed = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
            Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y)
        );

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemy.transform.parent = transform;
    }
}
