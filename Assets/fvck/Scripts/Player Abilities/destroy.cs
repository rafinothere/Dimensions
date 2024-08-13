using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    // This method is called when the collider attached to this object 
    // collides with another collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy this game object
            Destroy(gameObject);
        }
    }
}
