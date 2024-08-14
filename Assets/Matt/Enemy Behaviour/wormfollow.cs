using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormfollow : MonoBehaviour
{
    public Transform parentSquare; // Reference to the parent object
    public float lagSpeed = 2f; // Adjust the lag speed (smaller values = more lag)

    private Vector3 targetPosition;

    void Start()
    {
        // Initialize the target position with the object's current position
        targetPosition = transform.position;
    }

    void FixedUpdate()
    {
        // Ensure the parentSquare reference is not null
        if (parentSquare != null)
        {
            // Calculate the desired position relative to the parent
            Vector3 desiredPosition = parentSquare.position;

            // Smoothly interpolate the target position towards the desired position
            targetPosition = Vector3.Lerp(targetPosition, desiredPosition, lagSpeed * Time.fixedDeltaTime);

            // Update the object's position
            transform.position = targetPosition;
        }
    }
}