using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standardenemy : MonoBehaviour
{
    private enemyfollow follow;
    private enemyrandom random;
    void Start()
    {
        follow = GetComponent<enemyfollow>();
        random = GetComponent<enemyrandom>();
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(Vector2.Distance(transform.position,player.transform.position) < 10f)
        {
            random.enabled = false;
            follow.enabled = true;
        }
        
    }
}
