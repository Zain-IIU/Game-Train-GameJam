using System;
using DG.Tweening;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private AudioManager audioManager;
    
    private void Start()
    {
        audioManager=AudioManager.instance;
        player = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SoulPoint"))
        {   
            audioManager.Play("SoulPoint");
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
