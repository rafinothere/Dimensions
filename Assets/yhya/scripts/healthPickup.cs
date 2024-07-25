using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D Heal)
    {
        if (Heal.CompareTag("Player"))
        {
            Debug.Log("collision detected");
        }
    }
}
