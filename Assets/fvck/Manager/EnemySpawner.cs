using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 1000f;
    public float projectileDamage = 1f; // Damage value from projectiles
    public GameObject spawnPrefab; // Assign your prefab in the Inspector
    public float dropChance = 0.05f; // Public variable to set the drop chance

    void Update()
    {
        if (healthAmount <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            // Apply damage to the enemy from a projectile
            TakeDamage(projectileDamage);
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 1000f; // Adjusted to use 1000f for full health
    }

    private void Die()
    {
        // Add death logic here (e.g., play a death animation, destroy the enemy object, etc.)
        if (Random.Range(0f, 1f) <= dropChance) // Use the dropChance variable
        {
            Instantiate(spawnPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject); // Example: Destroy the enemy game object.
    }
}
