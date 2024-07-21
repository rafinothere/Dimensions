using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    public float projectileDamage = 20f; // Damage value from projectiles

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
            // Apply damage to the enemy
            TakeDamage(projectileDamage);
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    private void Die()
    {
        // Add death logic here (e.g., play a death animation, destroy the enemy object, etc.)
        Destroy(gameObject); // Example: Destroy the enemy game object.
    }
}
