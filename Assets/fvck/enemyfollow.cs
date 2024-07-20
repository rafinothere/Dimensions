using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfollow : MonoBehaviour
{
    public float speed = 3f; // Movement speed of the enemy

    void Update()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            
            Vector3 direction = playerObject.transform.position - transform.position;
            direction.Normalize(); 

            transform.position += direction * speed * Time.deltaTime;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.eulerAngles = new Vector3(0f, 0f, angle);
        }
    }
}