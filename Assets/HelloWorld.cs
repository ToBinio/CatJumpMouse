using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HelloWorld : MonoBehaviour
{
    [SerializeField] private string testVar = "Hello World";
    public void Start()
    {
        Debug.Log(testVar);
    }
}
