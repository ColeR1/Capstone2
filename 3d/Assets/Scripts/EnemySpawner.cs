using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyLevelSystem enemyPrefab;
    public Transform spawnPoint;

    private void Start() {
        SpawnRandomEnemy();
    }

    private void SpawnRandomEnemy()
    {
        // Generate a random level for the enemy
        EnemyLevelSystem.EnemyLevel randomLevel = (EnemyLevelSystem.EnemyLevel)Random.Range(0, 5);
        
        // Instantiate the enemy and set its level
        EnemyLevelSystem newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        newEnemy.SetLevel(randomLevel);
    }

    // Call SpawnRandomEnemy to spawn enemies as needed
}

