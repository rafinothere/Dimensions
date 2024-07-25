using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float spawnOffset = 0.5f;
    private bool enemySpawned = false; // Flag to check if an enemy has been spawned

    public GameObject enemyPrefab;  // Single enemy prefab

    private float elapsedTime = 0f;  // Time elapsed since projectile creation

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 0.5f && !enemySpawned)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(0.5f);

        if (!enemySpawned)
        {
            // Spawn the enemy prefab at the projectile's position
            Instantiate(enemyPrefab, transform.position, transform.rotation);

            enemySpawned = true; // Mark that the enemy has been spawned
        }
    }
}

