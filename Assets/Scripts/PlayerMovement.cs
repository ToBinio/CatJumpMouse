using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float _horizontal;
    private const float Speed = 8f;
    private const float JumpingPower = 16f;
    private bool _isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public event EventHandler OnMoveLeft;
    public event EventHandler OnMoveRight;
    
    private const int MaxJumps = 1;
    private int _jumpsRemaining = MaxJumps;

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && _jumpsRemaining > 0)
        {
            if (_jumpsRemaining == MaxJumps)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpingPower);
            }
            else {
                rb.velocity = new Vector2(rb.velocity.x, JumpingPower * 0.8f);
            }
            _jumpsRemaining--;
        }

        if (IsGrounded())
        {
            _jumpsRemaining = MaxJumps;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            var velocity = rb.velocity;
            velocity = new Vector2(velocity.x, velocity.y * 0.2f);
            rb.velocity = velocity;
        }
    
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_horizontal * Speed, rb.velocity.y);
    }

    private void Flip()
    {
        if ((!_isFacingRight || !(_horizontal < 0f)) && (_isFacingRight || !(_horizontal > 0f))) return;
        if (_isFacingRight)
        {
            OnMoveLeft?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            OnMoveRight?.Invoke(this, EventArgs.Empty);
        }
        _isFacingRight = !_isFacingRight;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
