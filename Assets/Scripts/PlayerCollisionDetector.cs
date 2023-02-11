using System;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{

    public bool touchesGround;
    [SerializeField] private LayerMask groundLayer;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if ((groundLayer.value & (1 << col.gameObject.layer)) > 0)
        {
            touchesGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if ((groundLayer.value & (1 << col.gameObject.layer)) > 0)
        {
            touchesGround = false;
        }
    }
}