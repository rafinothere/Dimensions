using UnityEngine;
using UnityEngine.InputSystem;

public class LeftClick : MonoBehaviour
{
    public float raycastRange = 100f;
    public string raycastTag = "RaycastBullet";
    public GameObject raycastObjectPrefab; // Assign this in the Inspector
    public float raycastObjectSpeed = 20f;

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
        // Create a ray from the camera's position pointing towards the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastRange))
        {
            // Instantiate the raycast object at the camera's position
            GameObject raycastObject = Instantiate(raycastObjectPrefab, Camera.main.transform.position, Quaternion.identity);
            raycastObject.tag = raycastTag;

            // Calculate direction to the hit point
            Vector3 direction = (hit.point - Camera.main.transform.position).normalized;

            // Set the raycast object's rotation to face the direction of travel
            raycastObject.transform.rotation = Quaternion.LookRotation(direction);

            // Add a Rigidbody and set its velocity
            Rigidbody rb = raycastObject.GetComponent<Rigidbody>();
            if (rb == null) rb = raycastObject.AddComponent<Rigidbody>();
            rb.velocity = direction * raycastObjectSpeed;

            // Optional: Destroy the raycast object after it reaches the hit point
            float distanceToTarget = Vector3.Distance(Camera.main.transform.position, hit.point);
            Destroy(raycastObject, distanceToTarget / raycastObjectSpeed);

            Debug.Log("Raycast object created and moving towards: " + hit.collider.gameObject.name);
        }
        else
        {
            Debug.Log("Raycast did not hit anything.");
        }
    }
}
