using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftClick : MonoBehaviour
{
    public float raycastRange = 100f; // Maximum range for the raycast

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
        // Cast a ray from the camera's position forward
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, raycastRange);

        if (hit.collider != null)
        {
            // Handle hit logic (e.g., apply damage, destroy enemies, etc.)
            Debug.Log("Hit: " + hit.collider.gameObject.name);
        }
    }
}