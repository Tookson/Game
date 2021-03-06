using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 300f;
    private Rigidbody _rigidbody;
    private Vector2 _movementVector;
    private bool jump;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue inputValue)
    {
        _movementVector = inputValue.Get<Vector2>();
    }
    
    void OnJump(InputValue inputValue)
    {
        jump = true;
    }

    private void FixedUpdate()
    {
        float y = 0f;
        if (jump)
        {
            y = jumpForce;
            jump = false;
        }
        Vector3 force = new Vector3(_movementVector.x * speed, y, _movementVector.y * speed);
        // _rigidbody.AddForce(force);
        _rigidbody.velocity = new Vector3(_movementVector.x * speed, y, _movementVector.y * speed);
    }
}
