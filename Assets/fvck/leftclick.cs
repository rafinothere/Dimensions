using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftClick : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign your projectile prefab in the Inspector
    public float projectileSpeed = 10f;
    public float projectileLifetime = 5.0f; // Time after which the projectile will be destroyed

    private void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            LeftShoot();
        }
    }

    private void LeftShoot()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure the same z-coordinate as the player

        // Calculate direction from player to mouse
        Vector3 shootDirection = (mousePosition - transform.position).normalized;

        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Set the projectile's collider to be a trigger
        Collider2D projectileCollider = projectile.GetComponent<Collider2D>();
        if (projectileCollider != null)
        {
            projectileCollider.isTrigger = true;
        }

        // Apply velocity to the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = shootDirection * projectileSpeed;
        }

        // Destroy the projectile after 'projectileLifetime' seconds
        Destroy(projectile, projectileLifetime);
    }
}
