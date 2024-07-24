using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D activate)
    {
        if (activate.CompareTag("Projectile"))
        {
            Dash();
        }
    }

    void Dash()
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag("Player");
        if (targetObject != null)
        {
            Debug.Log("player found");
        }
        
    }
}
