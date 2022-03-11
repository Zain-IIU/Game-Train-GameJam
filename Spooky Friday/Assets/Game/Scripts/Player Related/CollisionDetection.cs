using System;
using DG.Tweening;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;

    private void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SoulPoint"))
        {
            
            SpawnManager.instance.UpdateSpawnPoint(other.transform);
        }

        if (other.gameObject.CompareTag("Obstacle_Fire"))
        {
            other.enabled = false;
            other.GetComponent<FireObstacle>().DamagePlayer();
            player.DestroyPlayer();
        }
        if (other.gameObject.CompareTag("Obstacle_Pit"))
        {
            other.enabled = false;
            other.GetComponent<PitObstacle>().DamagePlayer();
            player.DestroyPlayer();
        }
    }
}
