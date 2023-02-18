using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNew : MonoBehaviour
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
    
    private bool _canDoubleJump = false;
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
                _canDoubleJump = false;
            }
            _jumpsRemaining--;
        }

        if (IsGrounded())
        {
            _jumpsRemaining = MaxJumps;
            _canDoubleJump = true;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            var velocity = rb.velocity;
            velocity = new Vector2(velocity.x, velocity.y * 0.5f);
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
        if (!_isFacingRight)
        {
            OnMoveLeft?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            OnMoveRight?.Invoke(this, EventArgs.Empty);
        }
        
        if (_isFacingRight && _horizontal < 0f || !_isFacingRight && _horizontal > 0f)
        {
            _isFacingRight = !_isFacingRight;
            var transform1 = transform;
            var localScale = transform1.localScale;
            localScale.x *= -1f;
            transform1.localScale = localScale;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
