using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class rightscript : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign your projectile prefab in the Inspector
    public float projectileSpeed = 10f;
    public float projectileLifetime = 5.0f; // Time after which the projectile will be destroyed
    private InputSystem inputs;

    private void Awake()
    {
        inputs = new InputSystem();
        inputs.Enable();
    }

    private void OnEnable()
    {
        inputs.MoveInput.ScrollAbility.performed += ScrollPerformed;
    }

    private void OnDisable()
    {
        inputs.MoveInput.ScrollAbility.performed -= ScrollPerformed;
        inputs.Disable();
    }

    private void Update()
    {
        // Check for right mouse button click
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            RightShoot();
        }
    }

    private void RightShoot()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
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

    private void ScrollPerformed(InputAction.CallbackContext context)
    {
        float scrollValue = context.ReadValue<float>();
        if (scrollValue > 0)
        {
            // Scroll up logic
            Debug.Log("Scrolling up");
        }
        else if (scrollValue < 0)
        {
            // Scroll down logic
            Debug.Log("Scrolling down");
        }
    }
}
