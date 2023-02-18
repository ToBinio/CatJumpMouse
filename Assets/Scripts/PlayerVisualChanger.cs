using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerVisualChanger : MonoBehaviour
{
    [SerializeField] private Material[] materials;

    [SerializeField] private PlayerMovement playerMovement;

    private int _currentMaterialIndex;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        UpdateMaterial();

        playerMovement.OnMoveLeft += (sender, args) =>
            _spriteRenderer.flipX = true;

        playerMovement.OnMoveRight += (sender, args) =>
            _spriteRenderer.flipX = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _currentMaterialIndex -= 1;
            _currentMaterialIndex += materials.Length;
            _currentMaterialIndex %= materials.Length;

            UpdateMaterial();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _currentMaterialIndex += 1;
            _currentMaterialIndex %= materials.Length;

            UpdateMaterial();
        }
    }

    private void UpdateMaterial()
    {
        _spriteRenderer.material = materials[_currentMaterialIndex];
    }
}