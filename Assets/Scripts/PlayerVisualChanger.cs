using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisualChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    private int _currentSpriteIndex;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        UpdateSprite();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _currentSpriteIndex -= 1;
            _currentSpriteIndex += sprites.Length;
            _currentSpriteIndex %= sprites.Length;
            
            UpdateSprite();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _currentSpriteIndex += 1;
            _currentSpriteIndex %= sprites.Length;
            
            UpdateSprite();
        }
    }

    private void UpdateSprite()
    {
        _spriteRenderer.sprite = sprites[_currentSpriteIndex];
    }
}