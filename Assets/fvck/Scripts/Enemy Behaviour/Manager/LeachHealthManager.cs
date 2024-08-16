using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeachHealthManager : MonoBehaviour
{
    public Image healthBar; // Reference to the health bar UI element
    public float healthAmount = 1000f; // Initial health amount
    public float projectileDamage = 1f; // Damage value from projectiles
    public float spawnOffset = 0.5f; // Offset for spawning new leach objects

    private bool isDead = false; // Flag to track if the leach is dead
    private int spawnedEnemyCount = 0; // Counter for spawned enemies

    void Update()
    {
        if (healthAmount <= 0 && !isDead)
        {
            StartCoroutine(SpawnEnemiesAndDie());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            TakeDamage(projectileDamage); // Apply damage to the enemy
        }
    }

    private void TakeDamage(float damage)
    {
        healthAmount -= damage; // Reduce health by the specified damage
        healthBar.fillAmount = healthAmount / 100f; // Update health bar UI
    }

    private IEnumerator SpawnEnemiesAndDie()
    {
        isDead = true; // Mark the leach as dead

        // Spawn enemies here (you can customize this part)
        SpawnEnemies();

        // Wait for a brief delay (e.g., 1 second) before destroying the object
        yield return new WaitForSeconds(1f);

        Destroy(gameObject); // Destroy the original leach object
    }

    private void SpawnEnemies()
    {
        if (spawnedEnemyCount < 2)
        {
            // Create two new leach objects by duplicating the current one
            Vector3 spawnPosition1 = transform.position + new Vector3(-spawnOffset, 0, 0);
            Vector3 spawnPosition2 = transform.position + new Vector3(spawnOffset, 0, 0);

            // Instantiate two clones of the current GameObject (your enemy prefabs)
            GameObject enemy1 = Instantiate(gameObject, spawnPosition1, transform.rotation);
            GameObject enemy2 = Instantiate(gameObject, spawnPosition2, transform.rotation);

            // Set full health for the spawned enemies
            enemy1.GetComponent<LeachHealthManager>().healthAmount = 100f;
            enemy2.GetComponent<LeachHealthManager>().healthAmount = 100f;

            spawnedEnemyCount++; // Increment the spawned enemy count
        }
    }
}
