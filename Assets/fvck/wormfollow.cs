using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormfollow : MonoBehaviour
{
    public Transform parentSquare; // Reference to the parent square
    public float lagSpeed = 200f; // Adjust the lag speed (smaller values = more lag)

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        // Calculate the desired position relative to the parent
        Vector3 desiredPosition = parentSquare.position;
        targetPosition = Vector3.Lerp(targetPosition, desiredPosition, lagSpeed * Time.deltaTime);
        transform.position = targetPosition;
    }
}