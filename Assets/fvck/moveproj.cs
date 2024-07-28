using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveproj : MonoBehaviour
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
}
