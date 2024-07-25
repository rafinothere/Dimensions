using System.Collections;
using UnityEngine;

/* I need for this script to switch between doing 2 things and the switch should happen for each shot
the first shot should have the tag of the projectile be PortalProjectile



*/


public class Projectile : MonoBehaviour
{
    public float spawnOffset = 0.5f;
    private bool enemySpawned = false; // Flag to check if an enemy has been spawned

    public GameObject enemyPrefab;  // Single enemy prefab

    private float elapsedTime = 0f;  // Time elapsed since projectile creation

    public float speed = 10f;  // Example property for speed

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

    // Method to initialize the projectile's properties
    public void Initialize(Vector3 direction, float projectileSpeed)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }
    }

    // Method to handle collision events
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the projectile hits an object with the "Enemy" tag
        if (collision.CompareTag("Enemy"))
        {
            // Destroy the projectile upon collision
            Destroy(gameObject);
        }
    }
}
