using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
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
        // Check if the projectile hits an object with the "Enemy" tag
        if (collision.CompareTag("Enemy"))
        {
            // Destroy the projectile upon collision
            Destroy(gameObject);
        }
    }
}
