using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushEnemies : MonoBehaviour
{
    private float radius = 10f;
    private float duration = 0f;
    private bool active;
    private float lifespan = 5f;
 
    void Update()
    {
        activeTime();
        lifetime();
    }

    void OnTriggerEnter2D(Collider2D activate)
    {
        if (activate.CompareTag("Projectile"))
        {
            duration = 5f;
        }
    }

    private void activeTime()
    {
        if(duration > 0)
        {
            Push();
            duration -= Time.deltaTime;
        }
        else if(active == true)
        {
            Destroy(gameObject);
        }
    }

    private void Push()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D collider in colliders)
        {
            if(collider.gameObject.tag == "Enemy")
            {
                active = true;
                float distance = (Vector2.Distance(transform.position, collider.gameObject.transform.position))*20;
                Vector2 relativePosition = (collider.gameObject.transform.position - transform.position)/distance;
                Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
                rb.velocity = rb.velocity + relativePosition;

            }
        }

    }

    private void lifetime()
    {
        if(lifespan > 0)
        {
            lifespan -= Time.deltaTime;
        }
        else if((active == false) && (gameObject.name != "Push"))
        {
            Destroy(gameObject);
        }
    }
}
