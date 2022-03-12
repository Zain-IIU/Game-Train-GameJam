using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
     [SerializeField] private ParticlesManager particlesManager;
    
    private void Start()
    {
        player = GetComponent<PlayerMovement>();
        particlesManager = ParticlesManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SoulPoint"))
        {
            other.enabled = false;
            particlesManager.PlaySoulPointVFX(other.transform);
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
        if (other.gameObject.CompareTag("Obstacle_Fog"))
        {
            other.enabled = false;
            other.GetComponent<FogObstacle>().DamagePlayer();
            player.DestroyPlayer();
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            UiManager.instance.EndFade();
        }

        if (other.gameObject.CompareTag("Arrow"))
        {
            Destroy(other.gameObject);
            player.DestroyPlayer();
        }
    }
}
