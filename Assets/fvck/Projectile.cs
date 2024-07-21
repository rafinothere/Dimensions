using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10f; // Example property for damage
    public float speed = 10f;  // Example property for speed

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
        // Example logic for when the projectile hits something
        Debug.Log("Projectile hit: " + collision.gameObject.name);

        // Example: Apply damage to the object hit if it has a health component
        Health targetHealth = collision.gameObject.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }

        // Destroy the projectile after it hits something
        Destroy(gameObject);
    }
}
