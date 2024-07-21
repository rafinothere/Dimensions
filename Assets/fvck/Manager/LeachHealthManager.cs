using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeachHealthManager : MonoBehaviour
{
    public Image healthBar; // Reference to the health bar UI element
    public float healthAmount = 100f; // Initial health amount
    public float projectileDamage = 20f; // Damage value from projectiles
    public float spawnOffset = 0.5f; // Offset for spawning new leach objects

    void Update()
    {
        if (healthAmount <= 0)
        {
            Die(); // Call Die() when health reaches 0
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            TakeDamage(projectileDamage); // Apply damage to the enemy
        }
    }

    private void Die()
    {
        Split(); // Split the leach into two identical leach enemies
        Destroy(gameObject); // Destroy the original leach object
    }

    private void Split()
    {
        // Create two new leach objects by duplicating the current one
        Vector3 spawnPosition1 = transform.position + new Vector3(-spawnOffset, 0, 0);
        Vector3 spawnPosition2 = transform.position + new Vector3(spawnOffset, 0, 0);

        // Instantiate two clones of the current GameObject
        Instantiate(gameObject, spawnPosition1, transform.rotation);
        Instantiate(gameObject, spawnPosition2, transform.rotation);
    }

    private void TakeDamage(float damage)
    {
        healthAmount -= damage; // Reduce health by the specified damage
        healthBar.fillAmount = healthAmount / 100f; // Update health bar UI
    }
}
