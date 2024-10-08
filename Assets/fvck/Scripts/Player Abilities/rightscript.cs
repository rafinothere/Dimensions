using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;

public class rightscript : MonoBehaviour
{
    public List<GameObject> projectilePrefabs; // List of enabled projectile prefabs
    public List<GameObject> disabledProjectilePrefabs; // List of disabled projectile prefabs
    public float projectileSpeed = 10f;
    public float projectileLifetime = 5.0f; // Time after which the projectile will be destroyed
    public TMP_Text projectileNameText; // Reference to the TextMeshPro UI element
    private InputSystem inputs;
    private int selectedProjectileIndex = 0; // Index of the currently selected projectile

    private const string UpgradeTag = "upgrade"; // Define the tag as a constant string

    private void Awake()
    {
        inputs = new InputSystem();
        inputs.Enable();
    }

    private void Start()
    {
        UpdateProjectileName();
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
        if (projectilePrefabs.Count == 0) return;

        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePosition.z = 0f; // Ensure the same z-coordinate as the player

        // Calculate direction from player to mouse
        Vector3 shootDirection = (mousePosition - transform.position).normalized;

        // Instantiate the selected projectile
        GameObject projectilePrefab = projectilePrefabs[selectedProjectileIndex];
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
        if (projectilePrefabs.Count == 0) return;

        float scrollValue = context.ReadValue<float>();
        if (scrollValue > 0)
        {
            // Scroll up logic
            selectedProjectileIndex = (selectedProjectileIndex + 1) % projectilePrefabs.Count;
        }
        else if (scrollValue < 0)
        {
            // Scroll down logic
            selectedProjectileIndex = (selectedProjectileIndex - 1 + projectilePrefabs.Count) % projectilePrefabs.Count;
        }
        UpdateProjectileName();
    }

    private void UpdateProjectileName()
    {
        if (projectileNameText != null && projectilePrefabs.Count > 0)
        {
            projectileNameText.text = "" + projectilePrefabs[selectedProjectileIndex].name;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collision detected with: {collision.gameObject.name}");
        if (collision.gameObject.CompareTag(UpgradeTag))
        {
            Debug.Log("Upgrade tag matched.");
            if (disabledProjectilePrefabs.Count > 0)
            {
                // Select a random disabled projectile
                int randomIndex = Random.Range(0, disabledProjectilePrefabs.Count);
                GameObject randomProjectile = disabledProjectilePrefabs[randomIndex];

                // Move the selected projectile to the enabled projectiles list
                projectilePrefabs.Add(randomProjectile);
                disabledProjectilePrefabs.RemoveAt(randomIndex);

                Debug.Log($"Moved {randomProjectile.name} from disabled to enabled projectiles list.");

                // Update the projectile name display if the list was previously empty
                if (projectilePrefabs.Count == 1)
                {
                    selectedProjectileIndex = 0;
                    UpdateProjectileName();
                }
            }
            else
            {
                Debug.Log("No disabled projectiles to enable.");
            }
        }
    }
}
