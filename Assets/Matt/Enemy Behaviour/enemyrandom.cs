using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyrandom : MonoBehaviour
{
    public float speed = 3f; // Movement speed of the enemy
    private Vector3 randomDirection; // Store the random movement direction
    private float timeSinceLastChange = 0f; // Keep track of time since last direction change
    private float changeDirectionInterval = 2f; // Change direction every 2 seconds

    void Start()
    {
        // Initialize random direction at the start
        randomDirection = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        // Check if it's time to change direction
        timeSinceLastChange += Time.deltaTime;
        if (timeSinceLastChange >= changeDirectionInterval)
        {
            // Generate a new random direction
            randomDirection = Random.insideUnitCircle.normalized;
            timeSinceLastChange = 0f; // Reset the timer
        }

        // Move in the current random direction
        transform.position += randomDirection * speed * Time.deltaTime;

        // Rotate to face the movement direction
        float angle = Mathf.Atan2(randomDirection.y, randomDirection.x) * Mathf.Rad2Deg - 90f;
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }
}