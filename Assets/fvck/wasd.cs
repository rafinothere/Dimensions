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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        rb.velocity = MoveInput * moveSpeed;
    }

    void Awake()
    {
        temp = new InputSystem();

        temp.MoveInput.MoveUp.performed += OnMoveUp;
        temp.MoveInput.MoveDown.performed += OnMoveDown;
        temp.MoveInput.MoveLeft.performed += OnMoveLeft;
        temp.MoveInput.MoveRight.performed += OnMoveRight;

        temp.MoveInput.MoveUp.canceled += OnMoveCanceled;
        temp.MoveInput.MoveDown.canceled += OnMoveCanceled;
        temp.MoveInput.MoveLeft.canceled += OnMoveCanceled;
        temp.MoveInput.MoveRight.canceled += OnMoveCanceled;

        temp.MoveInput.Enable();
    }

    void OnMoveUp(InputAction.CallbackContext context)
    {
        MoveInput = Vector2.up;
    }

    void OnMoveDown(InputAction.CallbackContext context)
    {
        MoveInput = Vector2.down;
    }

    void OnMoveLeft(InputAction.CallbackContext context)
    {
        MoveInput = Vector2.left;
    }

    void OnMoveRight(InputAction.CallbackContext context)
    {
        MoveInput = Vector2.right;
    }

    void OnMoveCanceled(InputAction.CallbackContext context)
    {
        MoveInput = Vector2.zero;
    }
}
