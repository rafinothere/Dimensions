using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class LeftClick : MonoBehaviour
{
    public GameObject attackObjectToSpawn;
    public float spawnDistance = 4f;
    public float attackDuration = 0.5f;
    public float shootingDelay = 0.9f; // Delay between shots

    private InputSystem inputs;
    private bool isShooting = false;
    private int activeShots = 0;
    private const int maxActiveShots = 2;
    private Coroutine shootingCoroutine;

    private void Awake()
    {
        inputs = new InputSystem();
        inputs.Enable();
    }

    private void OnEnable()
    {
        inputs.MoveInput.LeftShoot.performed += OnLeftShoot;
        inputs.MoveInput.LeftShoot.canceled += OnLeftShootCanceled;
    }

    private void OnDisable()
    {
        inputs.MoveInput.LeftShoot.performed -= OnLeftShoot;
        inputs.MoveInput.LeftShoot.canceled -= OnLeftShootCanceled;
        inputs.Disable();
    }

    private void OnLeftShoot(InputAction.CallbackContext context)
    {
        if (!isShooting)
        {
            isShooting = true;
            shootingCoroutine = StartCoroutine(HandleShooting());
        }
    }

    private void OnLeftShootCanceled(InputAction.CallbackContext context)
    {
        if (isShooting)
        {
            isShooting = false;
            StopCoroutine(shootingCoroutine);
        }
    }

    private IEnumerator HandleShooting()
    {
        while (isShooting)
        {
            if (activeShots < maxActiveShots)
            {
                LeftShoot();
            }
            yield return new WaitForSeconds(shootingDelay); // Wait for delay before next shot
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
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        //mousePosition.z = 0f; // Ensure the same z-coordinate as the player

        // Debugging: Log the mouse position
        Debug.Log("Mouse Position: " + mousePosition);
        // Calculate direction from player to mouse
        Vector3 attackDirection = (mousePosition - transform.position);

        // Debugging: Log the attack direction
        //Debug.Log("Attack Direction: " + attackDirection);

        // Calculate the spawn position
        Vector3 spawnPosition = transform.position + attackDirection * spawnDistance;

        // Calculate the rotation to face the mouse direction
        float angle = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (attackObjectToSpawn != null)
        {
            // Instantiate the attack object at the calculated position and rotation
            GameObject spawnedAttackObject = Instantiate(attackObjectToSpawn, spawnPosition, rotation);
            activeShots++;

            // Destroy the attack object after the specified duration
            Destroy(spawnedAttackObject, attackDuration);
            StartCoroutine(RemoveActiveShotAfterDelay(spawnedAttackObject, attackDuration));
        }
        else
        {
            Debug.LogError("Attack object to spawn is not assigned.");
        }
    }

    private IEnumerator RemoveActiveShotAfterDelay(GameObject attackObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        activeShots--;
    }
}
