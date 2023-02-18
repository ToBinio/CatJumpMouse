using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CheckPoint : MonoBehaviour
{
    private GameManager _gameManager;
    private BoxCollider2D _collider2D;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite activatedSprite;

    private void Start()
    {
        _gameManager = GetComponentInParent<GameManager>();

        _collider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;
        
        _gameManager.SetRespawnLocation(transform);

        _collider2D.enabled = false;
        spriteRenderer.sprite = activatedSprite;
    }
}