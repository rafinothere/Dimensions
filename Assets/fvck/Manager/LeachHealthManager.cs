using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeachHealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    public float projectileDamage = 20f; // Damage value from projectiles

    public GameObject leachPrefab; // Reference to the leach prefab
    public float splitRadius = 1f;  // Radius within which new leach objects will be spawned

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
        // Split the leach into two identical leach enemies
        Split();
        Destroy(gameObject); // Destroy the original leach object
    }

    private void Split()
    {
        if (leachPrefab != null)
        {
            // Create two new leach objects
            Instantiate(leachPrefab, transform.position + new Vector3(-splitRadius, 0, 0), Quaternion.identity);
            Instantiate(leachPrefab, transform.position + new Vector3(splitRadius, 0, 0), Quaternion.identity);
        }
    }
}