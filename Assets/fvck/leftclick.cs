using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class leftclick : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign your projectile prefab in the Inspector
    public float projectileSpeed = 10f;

    private InputSystem temp;

    private void Awake()
    {
        temp = new InputSystem();

        temp.MoveInput.LeftShoot.performed += (context) =>
        {
            LeftShoot();
        };

        temp.MoveInput.Enable();
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
        projectileCollider.isTrigger = true;

        // Apply velocity to the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = shootDirection * projectileSpeed;
    }
}
