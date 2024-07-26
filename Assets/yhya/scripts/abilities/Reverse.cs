using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse : MonoBehaviour
{
    public float speed = 10f;
    public List<GameObject> enemyPrefabs;  // List of enemy prefabs to spawn
    public float spawnDelay = 1f;  // Delay before the spawned enemy becomes active

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Method to initialize the projectile's properties
    public void Initialize(Vector3 direction, float projectileSpeed)
    {
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }
    }

    // Method to handle collision events
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the projectile hits an object with the "Enemy" tag
        if ((collision.CompareTag("Enemy")) || (collision.CompareTag("Projectile")))
        {
            Debug.Log("Hit");
            SpawnRandomEnemy();
            // Destroy the projectile upon collision
            Destroy(gameObject);
        }
    }

    private void SpawnRandomEnemy()
    {
        if (enemyPrefabs.Count > 0)
        {
            // Select a random enemy prefab from the list
            GameObject selectedEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

            // Instantiate the selected enemy at the projectile's position
            GameObject spawnedEnemy = Instantiate(selectedEnemyPrefab, transform.position, Quaternion.identity);

            // Disable the enemy's movement components for 1 second
            StartCoroutine(ActivateEnemyAfterDelay(spawnedEnemy));
        }
        else
        {
            Debug.LogWarning("No enemy prefabs assigned to the projectile!");
        }
    }

    private IEnumerator ActivateEnemyAfterDelay(GameObject enemy)
    {
        // Disable movement components (assuming the enemy uses Rigidbody2D for movement)
        Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
        if (enemyRb != null)
        {
            enemyRb.simulated = false;
        }

        // Wait for the specified delay
        yield return new WaitForSeconds(spawnDelay);

        // Re-enable movement components
        if (enemyRb != null)
        {
            enemyRb.simulated = true;
        }
    }
}