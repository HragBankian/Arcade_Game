using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemiesInWave = 5;
    public int numberOfWaves = 3;
    public float timeBetweenWaves = 5f;
    public float spawnZPosition = -1f;
    public float spawnXPosition = 10f;
    public float minTimeBetweenEnemySpawns = 0f;
    public float maxTimeBetweenEnemySpawns = 1.5f;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        for (int wave = 0; wave < numberOfWaves; wave++)
        {
            yield return StartCoroutine(SpawnEnemiesInWave());
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    IEnumerator SpawnEnemiesInWave()
    {
        for (int i = 0; i < numberOfEnemiesInWave; i++)
        {
            float randomYPosition = Random.Range(-3.7f, 3.7f);
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(spawnXPosition, randomYPosition, spawnZPosition), Quaternion.identity);
            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();

            if (enemyMovement != null)
            {
                float randomSpeed = Random.Range(2f, 5f); // Customize speed if needed
                enemyMovement.speed = randomSpeed;
            }

            float randomDelay = Random.Range(minTimeBetweenEnemySpawns, maxTimeBetweenEnemySpawns);
            yield return new WaitForSeconds(randomDelay);
        }
    }
}
