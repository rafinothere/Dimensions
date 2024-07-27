using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargerenemy : MonoBehaviour
{
    private enemyrandom random;
    private EnemyDash dash;

    void Start()
    {
        random = GetComponent<enemyrandom>();
        dash = GetComponent<EnemyDash>();
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(Vector2.Distance(transform.position,player.transform.position) < 20f)
        {
            random.enabled = false;
            dash.enabled = true;
        }
    }
}
