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
        if (other.gameObject.CompareTag("SoulPoint") && !player.PlayerDead())
        {
            other.enabled = false;
            particlesManager.PlaySoulPointVFX(other.transform);
            SpawnManager.instance.UpdateSpawnPoint(other.transform);
            AudioManager.instance.Play("SoulPoint");
        }
        
        if (other.gameObject.CompareTag("Obstacle_Fire"))
        {
            other.enabled = false;
            AudioManager.instance.Play("death_fire");
            other.GetComponent<FireObstacle>().DamagePlayer();
            player.DestroyPlayer();
        }
        if (other.gameObject.CompareTag("Obstacle_Pit"))
        {
            other.enabled = false;
            other.GetComponent<PitObstacle>().DamagePlayer();
            AudioManager.instance.Play("death_spike");
            player.DestroyPlayer();
        }
        if (other.gameObject.CompareTag("Obstacle_Fog"))
        {
            other.enabled = false;
            AudioManager.instance.Play("death");
            other.GetComponent<FogObstacle>().DamagePlayer();
            player.DestroyPlayer();
        }

        if (other.gameObject.CompareTag("Finish")&& !player.PlayerDead())
        {
            AudioManager.instance.Play("finish");
            UiManager.instance.EndFade();
        }

        if (other.gameObject.CompareTag("Arrow") && !player.PlayerDead())
        {
            Destroy(other.gameObject);
            AudioManager.instance.Play("death");
            player.DestroyPlayer();
        }

        if (other.gameObject.CompareTag("Kill")&& !player.PlayerDead() )
        {
            AudioManager.instance.Play("death");
            player.DestroyPlayer();
        }

        if (other.gameObject.CompareTag("closeUp"))
        {
            CameraManager.instance.ZoomCamera(20f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("closeUp"))
        {
            CameraManager.instance.ZoomCamera(10f);
        }
    }
}
