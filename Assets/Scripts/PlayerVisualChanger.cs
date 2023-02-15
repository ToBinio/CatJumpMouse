using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisualChanger : MonoBehaviour
{
    [SerializeField] private Material[] materials;

    private int _currentMaterialIndex;
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
            _currentMaterialIndex -= 1;
            _currentMaterialIndex += materials.Length;
            _currentMaterialIndex %= materials.Length;
            
            UpdateSprite();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _currentMaterialIndex += 1;
            _currentMaterialIndex %= materials.Length;
            
            UpdateSprite();
        }
    }

    private void UpdateSprite()
    {
        _spriteRenderer.material = materials[_currentMaterialIndex];
    }
}