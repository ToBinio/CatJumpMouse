using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(PlayerCollisionDetector))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private PlayerCollisionDetector _playerCollisionDetector; 
    [SerializeField] private float movingSpeed = 110;
    [SerializeField] private float jumpHeight = 2500;

    private bool _shouldJump;
    private int _jumpCount;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerCollisionDetector = GetComponent<PlayerCollisionDetector>();
    }

    private void Update()
    {
        if (_playerCollisionDetector.touchesGround) _jumpCount = 0;
        
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        if (_jumpCount >= 1) return;
        _shouldJump = true;
        _jumpCount++;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody2D.AddForce(Vector2.left * movingSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody2D.AddForce(Vector2.right * movingSpeed);
        }

        if (!_shouldJump) return;
        _rigidbody2D.AddForce(Vector2.up * jumpHeight);
        _shouldJump = false;
    }
}