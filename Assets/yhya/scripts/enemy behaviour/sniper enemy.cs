using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniperenemy : MonoBehaviour
{
    private enemyrandom random;
    private enemyrun run;
    private pauseshot shoot;

    void Start()
    {
        random = GetComponent<enemyrandom>();
        run = GetComponent<enemyrun>();
        shoot = GetComponent<pauseshot>();
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(Vector2.Distance(transform.position,player.transform.position) > 50f)
        {
            random.enabled = true;
            run.enabled = false;
            shoot.enabled = false;
        }
        else if ((Vector2.Distance(transform.position,player.transform.position) < 50f) && (Vector2.Distance(transform.position,player.transform.position) > 5f))
        {
            random.enabled = false;
            run.enabled = false;
            shoot.enabled = true;
        }
        else
        {
            random.enabled = false;
            run.enabled = true;
            shoot.enabled = false;
        }

    }

}
