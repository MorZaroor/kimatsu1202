using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;
    public float spawnHeight = 600f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnRate);
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-850f, 850f);
        Vector2 spawnPosition = new Vector2(randomX, spawnHeight);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
