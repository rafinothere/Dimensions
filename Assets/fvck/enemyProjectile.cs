using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 10f;  // Projectile speed
    public float fireRate = 2f;  // Time gap between shots (in seconds)
    public float detectionRadius = 5f;  // Radius within which the player can be detected

    public GameObject projectilePrefab;  // Reference to the projectile prefab

    private Transform player;  // Reference to the player's transform
    private float nextFireTime;  // Time when the next shot can be fired

    private void Start()
    {
        // Find the player object (you can set this reference in the Inspector)
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextFireTime = Time.time;  // Initialize the next fire time
    }

    private void Update()
    {
        // Check if it's time to fire
        if (Time.time >= nextFireTime)
        {
            ShootTowardsPlayer();
            nextFireTime = Time.time + 1f / fireRate;  // Update the next fire time
        }
    }

    private void ShootTowardsPlayer()
    {
        if (player == null)
            return;  // Player not found, do nothing

        Vector3 direction = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Instantiate the chosen projectile prefab
                GameObject newProjectile = Instantiate(projectilePrefab,(transform.position + direction), Quaternion.identity);
                // Set the projectile's velocity
                newProjectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the projectile hits an object with the "Player" tag
        if (collision.CompareTag("Player"))
        {
            // Destroy the projectile upon collision
            Destroy(gameObject);
        }
    }
}
