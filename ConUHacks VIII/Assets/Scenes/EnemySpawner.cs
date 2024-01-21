using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Reference to the enemy prefab
    public int numberOfEnemiesInWave = 5;  // Number of enemies to spawn in each wave
    public int numberOfWaves = 3;  // Total number of waves
    public float timeBetweenWaves = 5f;  // Time between each wave
    public float spawnZPosition = -1f;  // Z position at which the enemies should spawn
    public float spawnXPosition = 10f;  // X position at which the enemies should spawn
    public float minTimeBetweenEnemySpawns = 0f;  // Minimum time delay between each enemy spawn within a wave
    public float maxTimeBetweenEnemySpawns = 1.5f;  // Maximum time delay between each enemy spawn within a wave

    void Start()
    {
        // Start the wave spawning process
        StartCoroutine(SpawnWaves());
    }

    System.Collections.IEnumerator SpawnWaves()
    {
        for (int wave = 0; wave < numberOfWaves; wave++)
        {
            // Spawn enemies in the current wave
            yield return StartCoroutine(SpawnEnemiesInWave());

            // Wait for the specified time before the next wave
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    System.Collections.IEnumerator SpawnEnemiesInWave()
    {
        for (int i = 0; i < numberOfEnemiesInWave; i++)
        {
            // Calculate a random Y position within the range [-4, 4]
            float randomYPosition = Random.Range(-4f, 4f);

            // Instantiate an enemy at the specified position with locked Z and X positions
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(spawnXPosition, randomYPosition, spawnZPosition), Quaternion.identity);

            // You can customize the enemy further if needed (e.g., change sprite, set health, etc.)
            // Access the EnemyMovement script and modify properties if necessary
            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                // Customize enemy movement properties if needed
                // Example: enemyMovement.speed = 4f;
            }

            // Wait for a random time between spawns within the specified range
            float randomDelay = Random.Range(minTimeBetweenEnemySpawns, maxTimeBetweenEnemySpawns);
            yield return new WaitForSeconds(randomDelay);
        }
    }
}