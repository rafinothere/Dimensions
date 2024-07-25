using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;  // List of enemy prefabs

    private float spawnDelay = 1f;  // Delay in seconds before spawning the enemy


    // Method to initialize the projectile's properties
    public void Initialize(Vector3 direction)
    {
        // No need to set velocity based on speed

        // Set the initial position
        Vector3 spawnPosition = transform.position;

        // Spawn a random enemy from the list
        if (enemyPrefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Count);
            Instantiate(enemyPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        }
    }

    // Method to handle collision events (unchanged)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
