using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyrun : MonoBehaviour
{
    public float speed = 3f; // Movement speed of the enemy
    private float detectRange = 15f;

    void Update()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            float distance = Vector2.Distance(transform.position, playerObject.transform.position);
            if (distance < detectRange)
            {
                Vector3 direction = transform.position - playerObject.transform.position; // Reverse the direction
                direction.Normalize();
                transform.position += direction * speed * Time.deltaTime;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                transform.eulerAngles = new Vector3(0f, 0f, angle);
            }
        }
    }
}
