using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDash : MonoBehaviour
{
    public float dashSpeed = 10f; // Speed during the dash
    private float dashDuration = 1f; // Duration of the dash in seconds
    private float dashTimer = 0f; // Timer for tracking dash duration
    private Vector3 dashDirection; // Direction of the dash
    private bool isDashing = false; // Flag to indicate if dashing
    public float detectRange = 15f; // Detection range for the player

    void Update()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            float distance = Vector2.Distance(transform.position, playerObject.transform.position);
            if (distance < detectRange)
            {
                // Start dashing towards the player's last known position
                if (!isDashing)
                {
                    isDashing = true;
                    dashDirection = (playerObject.transform.position - transform.position).normalized;
                }

                // Perform the dash
                if (isDashing)
                {
                    dashTimer += Time.deltaTime;
                    if (dashTimer < dashDuration)
                    {
                        transform.position += dashDirection * dashSpeed * Time.deltaTime;
                    }
                    else
                    {
                        // Dash duration elapsed, stop moving
                        isDashing = false;
                        dashTimer = 0f;
                    }
                }
            }
        }
    }
}
