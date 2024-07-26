using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoy : MonoBehaviour
{
    private GameObject player;
    private float duration = 0;
    private bool active;
    private float lifespan = 5f;

    void Update()
    {
        activePeriod();
        lifetime();
    }

    void OnTriggerEnter2D(Collider2D activate)
    {
        if (activate.CompareTag("Projectile"))
        {
            if(duration <= 0)
            {
                activateDecoy();
            }
        }   
    }
    
    private void activateDecoy()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.tag = "Player(invis)";
        gameObject.tag = "Player";
        duration = 5f;
        active = true;

    }

    private void activePeriod()
    {
        if(duration > 0)
        {
            duration -= Time.deltaTime;
        }
        else if(active == true)
        {
            player.tag = "Player";
            gameObject.tag = "Decoy(inactive)";
            Destroy(gameObject);
        }
    }

    private void lifetime()
    {
        if(lifespan > 0)
        {
            lifespan -= Time.deltaTime;
        }
        else if((active == false) && (gameObject.name == "Decoy(Clone)"))
        {
            Destroy(gameObject);
        }
    }

}
