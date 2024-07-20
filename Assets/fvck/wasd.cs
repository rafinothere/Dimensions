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

        temp.MoveInput.MoveUp.performed += (context) => 
        { 
            MoveUp(); 
        };
        temp.MoveInput.MoveDown.performed += (context) => 
        { 
            MoveDown(); 
        };
        temp.MoveInput.MoveLeft.performed += (context) => 
        { 
            MoveLeft(); 
        };
        temp.MoveInput.MoveRight.performed += (context) => 
        { 
            MoveRight(); 
        };

        temp.MoveInput.Enable();
    }

    void MoveUp()
    {
        MoveInput = Vector2.up;
    }

    void MoveDown()
    {
        MoveInput = Vector2.down;
    }

    void MoveLeft()
    {
        MoveInput = Vector2.left;
    }

    void MoveRight()
    {
        MoveInput = Vector2.right;
    }
    
}
