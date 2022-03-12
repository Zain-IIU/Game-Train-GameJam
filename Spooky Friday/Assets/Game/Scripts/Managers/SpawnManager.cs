using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{

    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private Transform respawnPoint;

    [SerializeField] private Material checkPointMaterial;

    private void Start()
    {
        RespawnPlayer();
    }

    [ContextMenu("Player Respawn")]
    public void RespawnPlayer()
    { 
        GameObject player=Instantiate(playerPrefab,respawnPoint.position,quaternion.identity);
    }

    public void UpdateSpawnPoint(Transform newPoint)
    {
        AudioManager.instance.Play("SoulPoint");
        respawnPoint = newPoint;
        newPoint.GetChild(0).GetComponent<MeshRenderer>().material = checkPointMaterial;
    }

}
