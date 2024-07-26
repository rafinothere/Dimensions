using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour
{
    private GameObject Player;
    private float dashDistance;
    private Vector2 dashDirection;
    private wasd playerController;
    private Rigidbody2D rb;
    private bool dashing = false;
    private float lifespan = 5f;
    
    void Update()
    {
        findPlayer();
        endDash();
        lifetime();
    }
    void OnTriggerEnter2D(Collider2D activate)
    {
        if (activate.CompareTag("Projectile"))
        {
            Dash();
        }
    }

    private void Dash()
    {
        playerController.enabled = false;
        rb.velocity = rb.velocity + dashDirection;
        dashing = true;
    }

    private void findPlayer()
    {
        Player = GameObject.FindGameObjectWithTag("Player(invis)");
        if(Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        dashDistance = Vector2.Distance(transform.position,Player.gameObject.transform.position);
        dashDirection = (transform.position - Player.gameObject.transform.position)*dashDistance;
        playerController = Player.GetComponent<wasd>();
        rb = Player.GetComponent<Rigidbody2D>();
    }

    private void endDash()
    {
        if((dashing == true) && (rb.velocity.magnitude < 3))
        {
            dashing = false;
            playerController.enabled = true;
            rb.velocity = new Vector2(0,0);
            Destroy(gameObject);
        }
    }

    private void lifetime()
    {
        if(lifespan > 0)
        {
            lifespan -= Time.deltaTime;
        } 
        else if((dashing == false) && (gameObject.name == "dash projectile(Clone)"))
        {
            Destroy(gameObject);
        }
    }
}
