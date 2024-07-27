using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taggerenemy : MonoBehaviour
{
    private enemyrandom random;
    private hitNrun hitrun;
    
    void Start()
    {
        random = GetComponent<enemyrandom>();
        hitrun = GetComponent<hitNrun>();
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(Vector2.Distance(transform.position,player.transform.position) < 10f)
        {
            random.enabled = false;
            hitrun.enabled = true;
        }
    }
}
