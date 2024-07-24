using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullEnemies : MonoBehaviour
{
    private float radius = 10f;
    private float duration = 0f;

    void OnTriggerEnter2D(Collider2D activate)
    {
        if (activate.CompareTag("Projectile"))
        {
            Debug.Log("active");
            duration = 5f;
        }
    }

    private void activeTime()
    {
        if(duration > 0)
        {
            Pull();
            duration -= Time.deltaTime;
        }
    }

    private void Pull()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D collider in colliders)
        {
            if(collider.gameObject.tag == "Enemy")
            {
                float distance = (Vector2.Distance(transform.position, collider.gameObject.transform.position))*50;
                Vector2 relativePosition = (transform.position - collider.gameObject.transform.position)/distance;
                Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
                rb.velocity = rb.velocity + relativePosition;
            }
        }

    }
    
    void Update()
    {
        activeTime();
    }
}
