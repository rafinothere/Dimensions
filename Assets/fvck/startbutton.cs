using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startbutton : MonoBehaviour
{
    private GameObject player;
    private wasd playerControl;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerControl = player.GetComponent<wasd>();
    }

    void OnTriggerEnter2D(Collider2D start)
    {
        if (start.CompareTag("Projectile"))
        {
            playerControl.enabled = true;
            Destroy(gameObject);
        }
    }
}
