using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HealthPickup"))
        {
            Debug.Log("collision detected");
        }
    }

    private void Heal()
    {

    }
}
