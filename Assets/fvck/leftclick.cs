using UnityEngine;
using UnityEngine.InputSystem;

public class LeftClick : MonoBehaviour
{
    public GameObject objectToSpawn; // Assign the object to spawn in the Inspector
    public float spawnDistance = 2f; // Distance in front of the player to spawn the object

    private InputSystem inputSystem;
    private InputAction leftShootAction;

    private void Awake()
    {
        inputSystem = new InputSystem();
    }

    private void OnEnable()
    {
        inputSystem.Enable();
        leftShootAction = inputSystem.MoveInput.LeftShoot;
        leftShootAction.performed += OnLeftShoot;
        leftShootAction.Enable();
    }

    private void OnDisable()
    {
        leftShootAction.performed -= OnLeftShoot;
        leftShootAction.Disable();
        inputSystem.Disable();
    }

    private void OnLeftShoot(InputAction.CallbackContext context)
    {
        // Calculate the position in front of the player
        Vector3 spawnPosition = transform.position + transform.forward * spawnDistance;

        // Get the mouse position in world space
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Set the spawn position to the point where the ray intersects with the ground
            spawnPosition = hit.point;
        }

        // Instantiate the object at the calculated position and player's rotation
        Instantiate(objectToSpawn, spawnPosition, transform.rotation);
    }
}
