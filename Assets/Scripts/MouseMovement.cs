using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Serialization;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;

    [SerializeField] private LayerMask groundLayer;

    private bool _turnLeft;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_turnLeft)
        {
            _rigidbody2D.AddForce(Vector2.left * speed);

            if (!Physics2D.Raycast(leftPoint.position, Vector3.down, 0.5f, groundLayer) || Physics2D.Raycast(leftPoint.position, Vector3.left, 0.5f, groundLayer))
            {
                _turnLeft = false;
            }
        }
        else
        {
            _rigidbody2D.AddForce(Vector2.right * speed);

            if (!Physics2D.Raycast(rightPoint.position, Vector3.down, 0.5f, groundLayer) || Physics2D.Raycast(rightPoint.position, Vector3.right, 0.5f, groundLayer))
            {
                _turnLeft = true;
            }
        }
    }
}