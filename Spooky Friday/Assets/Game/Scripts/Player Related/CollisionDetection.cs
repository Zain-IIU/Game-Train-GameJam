using System;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SoulPoint"))
        {
            SpawnManager.instance.UpdateSpawnPoint(other.transform);
        }
    }
}
