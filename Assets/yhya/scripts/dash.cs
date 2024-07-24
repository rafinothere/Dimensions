using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D activate)
    {
        if (activate.CompareTag("Projectile"))
        {
            Dash();
        }
    }

    void Dash()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Vector2 dashDirection = (transform.position - Player.gameObject.transform.position)*10;
        wasd playerController = Player.GetComponent<wasd>();
        playerController.enabled = false;
        Rigidbody2D rb = Player.GetComponent<Rigidbody2D>();
        rb.velocity = rb.velocity + dashDirection;
        Debug.Log(rb.velocity);
    }
}
