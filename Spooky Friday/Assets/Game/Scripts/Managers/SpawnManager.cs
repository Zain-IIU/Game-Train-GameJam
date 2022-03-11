using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{

    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private Transform respawnPoint;

    [SerializeField] private Material checkPointMaterial;
    [ContextMenu("Player Respawn")]
    public void RespawnPlayer()
    { 
        GameObject player=Instantiate(playerPrefab,respawnPoint.position,quaternion.identity);
    }

    public void UpdateSpawnPoint(Transform newPoint)
    {
        respawnPoint = newPoint;
        newPoint.GetChild(0).GetComponent<MeshRenderer>().material = checkPointMaterial;
    }

}
