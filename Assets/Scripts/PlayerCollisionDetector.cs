using System;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{

    public bool touchesGround;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Platform")
        {
            touchesGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "Platform")
        {
            touchesGround = false;
        }
    }
}