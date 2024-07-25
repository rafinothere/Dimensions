using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immovable : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to this game object
        rb = GetComponent<Rigidbody>();

        // Ensure the Rigidbody is not kinematic so that physics interactions are possible
        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on " + gameObject.name);
        }
    }

    // This method is called when another collider enters the collision with this collider
    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Counteract the force applied by the enemy
            rb.AddForce(-collision.impulse, ForceMode.Impulse);
        }
    }

    // This method is called when another collider stays in contact with this collider
    void OnCollisionStay(Collision collision)
    {
        // Check if the colliding object has the tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Counteract the continuous force applied by the enemy
            rb.AddForce(-collision.relativeVelocity * collision.rigidbody.mass, ForceMode.Acceleration);
        }
    }
}
