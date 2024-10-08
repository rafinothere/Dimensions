using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overshoot : MonoBehaviour
{
    public float speed = 3f; // Movement speed of the enemy
    private float detectRange = 15f;
    private bool isTargetingPlayer = true;

    void Update()
    {
        if (isTargetingPlayer)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                float distance = Vector2.Distance(transform.position, playerObject.transform.position);
                if (distance < detectRange)
                {
                    Vector3 direction = playerObject.transform.position - transform.position;
                    direction.Normalize(); 
                    transform.position += direction * speed * Time.deltaTime;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                    transform.eulerAngles = new Vector3(0f, 0f, angle);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StopTargetingPlayer());
        }
    }

    IEnumerator StopTargetingPlayer()
    {
        isTargetingPlayer = false;
        yield return new WaitForSeconds(2f);
        isTargetingPlayer = true;
    }
}
