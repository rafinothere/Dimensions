using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangerenemy : MonoBehaviour
{
    private enemyrandom random;
    private EnemyProjectile shoot;
    private enemyCircle circle;
    void Start()
    {
        random = GetComponent<enemyrandom>();
        shoot = GetComponent<EnemyProjectile>();
        circle = GetComponent<enemyCircle>();
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(Vector2.Distance(transform.position,player.transform.position) > 10f)
        {
            random.enabled = true;
            shoot.enabled = false;
            circle.enabled = false;
        }
        else
        {
            random.enabled = false;
            shoot.enabled = true;
            circle.enabled = true;
        }
        }
}
