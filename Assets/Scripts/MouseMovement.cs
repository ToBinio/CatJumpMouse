using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;

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

            if (!Physics2D.Raycast(leftPoint.position, Vector3.down, 0.5f))
            {
                _turnLeft = false;
            }
        }
        else
        {
            _rigidbody2D.AddForce(Vector2.right * speed);

            if (!Physics2D.Raycast(rightPoint.position, Vector3.down, 0.5f))
            {
                _turnLeft = true;
            }
        }
    }
}