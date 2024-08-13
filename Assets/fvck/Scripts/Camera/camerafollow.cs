using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform player; 
    public float followSpeed = 5f; 

    private Vector3 offset; 

    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
    }
}