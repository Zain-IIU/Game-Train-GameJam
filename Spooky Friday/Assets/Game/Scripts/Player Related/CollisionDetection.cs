using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
     [SerializeField] private ParticlesManager particlesManager;
     [SerializeField] private AudioSource source;
     [SerializeField] private AudioClip[] clips;
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
            AudioManager.instance.PlaySoundWithAudioSource(source,clips[0]);
        }
        
        if (other.gameObject.CompareTag("Obstacle_Fire"))
        {
            other.enabled = false;
            AudioManager.instance.PlaySoundWithAudioSource(source,clips[1]);
            other.GetComponent<FireObstacle>().DamagePlayer();
            player.DestroyPlayer();
        }
        if (other.gameObject.CompareTag("Obstacle_Pit"))
        {
            other.enabled = false;
            other.GetComponent<PitObstacle>().DamagePlayer();
            AudioManager.instance.PlaySoundWithAudioSource(source,clips[1]);
            player.DestroyPlayer();
        }
        if (other.gameObject.CompareTag("Obstacle_Fog"))
        {
            other.enabled = false;
            AudioManager.instance.PlaySoundWithAudioSource(source,clips[1]);
            other.GetComponent<FogObstacle>().DamagePlayer();
            player.DestroyPlayer();
        }

        if (other.gameObject.CompareTag("Finish")&& !player.PlayerDead())
        {
            AudioManager.instance.PlaySoundWithAudioSource(source,clips[2]);
            UiManager.instance.EndFade();
        }

        if (other.gameObject.CompareTag("Arrow") && !player.PlayerDead())
        {
            Destroy(other.gameObject);
            AudioManager.instance.PlaySoundWithAudioSource(source,clips[1]);
            player.DestroyPlayer();
        }

        if (other.gameObject.CompareTag("Kill")&& !player.PlayerDead() )
        {
            AudioManager.instance.PlaySoundWithAudioSource(source,clips[1]);
            player.DestroyPlayer();
        }
    }

   
}
