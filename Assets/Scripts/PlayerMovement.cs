using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCollisionDetector))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private PlayerCollisionDetector _playerCollisionDetector;
    [SerializeField] private float _movingSpeed = 10;
    [SerializeField] private float _jumpHeight = 2500;

    private bool _shouldJump;
    private int _jumpCount = 0;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerCollisionDetector = GetComponent<PlayerCollisionDetector>();
    }

    private void Update()
    {
        if (_playerCollisionDetector.touchesGround)
        {
            _jumpCount = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_jumpCount < 1)
            {
                _shouldJump = true;
                _jumpCount++;
            }
        }
        

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody2D.AddForce(Vector2.left * _movingSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody2D.AddForce(Vector2.right * _movingSpeed);
        }

        if (_shouldJump)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpHeight);
            _shouldJump = false;
        }
    }
}