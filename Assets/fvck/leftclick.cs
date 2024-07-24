using UnityEngine;
using UnityEngine.InputSystem;

public class LeftClick : MonoBehaviour
{
    public float raycastRange = 100f;
    public LayerMask raycastLayerMask; // Set this in the Inspector

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
        ShootRaycast();
    }

    private void ShootRaycast()
    {
        // Get the mouse position in the world space
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        // Debug.DrawRay to visualize the ray in the Scene view
        Debug.DrawRay(ray.origin, ray.direction * raycastRange, Color.red, 2f);

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, raycastRange, raycastLayerMask))
        {
            // Raycast hit something
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
            // Handle hit logic here
        }
        else
        {
            // Raycast did not hit anything
            Debug.Log("Raycast did not hit anything.");
        }
    }
}
