using UnityEngine;
using UnityEngine.InputSystem;

public class LeftClick : MonoBehaviour
{
    public GameObject attackObjectToSpawn;
    public float spawnDistance = 4f;
    public float attackDuration = 0.5f;

    private InputSystem inputs;

    private void Awake()
    {
        inputs = new InputSystem();
        inputs.Enable();
    }

    private void OnEnable()
    {
        inputs.MoveInput.LeftShoot.performed += OnLeftShoot;
    }

    private void OnDisable()
    {
        inputs.MoveInput.LeftShoot.performed -= OnLeftShoot;
        inputs.Disable();
    }

    private void Update()
    {
        // Check for left mouse button click
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            LeftShoot();
        }
    }

    private void LeftShoot()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Main camera not found.");
            return;
        }

        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePosition.z = 0f; // Ensure the same z-coordinate as the player

        // Calculate direction from player to mouse
        Vector3 attackDirection = (mousePosition - transform.position).normalized;

        // Calculate the spawn position
        Vector3 spawnPosition = transform.position + attackDirection * spawnDistance;

        // Calculate the rotation to face the mouse direction
        float angle = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (attackObjectToSpawn != null)
        {
            // Instantiate the attack object at the calculated position and rotation
            GameObject spawnedAttackObject = Instantiate(attackObjectToSpawn, spawnPosition, rotation);

            // Destroy the attack object after the specified duration
            Destroy(spawnedAttackObject, attackDuration);
        }
        else
        {
            Debug.LogError("Attack object to spawn is not assigned.");
        }
    }

    private void OnLeftShoot(InputAction.CallbackContext context)
    {
        LeftShoot();
    }
}