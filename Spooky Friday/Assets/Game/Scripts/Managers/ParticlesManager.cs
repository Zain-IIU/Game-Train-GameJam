﻿using DG.Tweening;
using UnityEngine;

public class ParticlesManager : MonoSingleton<ParticlesManager>
{
    [SerializeField] private GameObject soulPointVFX;
    [SerializeField] private GameObject respawnVFX;

    public void PlaySoulPointVFX(Transform posToPlay)
    {
        soulPointVFX.transform.DOMove(posToPlay.position,0f).OnComplete(() =>
        {
            soulPointVFX.SetActive(true);    
        });
        
    }
    public void PlayRespawnVFX(Transform posToPlay)
    {
        respawnVFX.transform.DOMove(posToPlay.position,0f).OnComplete(() =>
        {
            respawnVFX.SetActive(true);    
        });
        
    }
}