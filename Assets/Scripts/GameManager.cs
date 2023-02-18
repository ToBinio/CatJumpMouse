using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform respawnSpawnPos;

    [SerializeField] private Transform player;

    [SerializeField] private float minHeight;

    private void Start()
    {
        player.position = respawnSpawnPos.position;
    }

    private void PlayerDeath()
    {
        player.transform.position = respawnSpawnPos.position;
    }

    public void SetRespawnLocation(Transform location)
    {
        respawnSpawnPos = location;
    }

    private void Update()
    {
        if (player.transform.position.y < minHeight)
            PlayerDeath();
    }
}