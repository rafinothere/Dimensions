using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCircle : MonoBehaviour
{
    private Rigidbody2D rb;
    private float distanceToPlayer;
    private GameObject player;
    private Vector2 playerPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        findPlayer();
        if (distanceToPlayer > 8f)
        {
            aproach();
            
        }
        else if(distanceToPlayer < 2)
        {
            retreat();
        }
        else
        {
            circlePlayer();
        }
    }

    private void circlePlayer()
    {
        Vector2 tangent = new Vector2(-playerPosition.y, playerPosition.x);
        rb.velocity = tangent;
        float angle = Mathf.Atan2(-playerPosition.y, -playerPosition.x) * Mathf.Rad2Deg - 90f;
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private void aproach()
    {
        rb.velocity = -playerPosition;
        float angle = Mathf.Atan2(-playerPosition.y, -playerPosition.x) * Mathf.Rad2Deg - 90f;
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private void retreat()
    {
        rb.velocity = playerPosition;
        float angle = Mathf.Atan2(playerPosition.y, playerPosition.x) * Mathf.Rad2Deg - 90f;
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private void findPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        distanceToPlayer = Vector2.Distance(transform.position,player.transform.position);
        playerPosition = (transform.position - player.transform.position);
    }
}
