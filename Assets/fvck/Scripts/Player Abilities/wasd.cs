using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class wasd : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    InputSystem temp;
    private Vector2 MoveInput;

    private bool isMovingUp;
    private bool isMovingDown;
    private bool isMovingLeft;
    private bool isMovingRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        Vector2 direction = Vector2.zero;
        if (isMovingUp) direction += Vector2.up;
        if (isMovingDown) direction += Vector2.down;
        if (isMovingLeft) direction += Vector2.left;
        if (isMovingRight) direction += Vector2.right;

        MoveInput = direction.normalized;
        rb.velocity = MoveInput * moveSpeed;
    }

    void Awake()
    {
        temp = new InputSystem();

        temp.MoveInput.MoveUp.performed += context => isMovingUp = true;
        temp.MoveInput.MoveUp.canceled += context => isMovingUp = false;

        temp.MoveInput.MoveDown.performed += context => isMovingDown = true;
        temp.MoveInput.MoveDown.canceled += context => isMovingDown = false;

        temp.MoveInput.MoveLeft.performed += context => isMovingLeft = true;
        temp.MoveInput.MoveLeft.canceled += context => isMovingLeft = false;

        temp.MoveInput.MoveRight.performed += context => isMovingRight = true;
        temp.MoveInput.MoveRight.canceled += context => isMovingRight = false;

        temp.MoveInput.Enable();
    }
}
