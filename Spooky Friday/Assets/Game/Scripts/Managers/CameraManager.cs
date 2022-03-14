using System;
using Cinemachine;
using DG.Tweening;
using UnityEngine;


public class CameraManager : MonoSingleton<CameraManager>
{
    [SerializeField] private CinemachineVirtualCamera _freeLook;

    private void Start()
    {
       ZoomCamera(10f);
    }

    public void UpdateTarget(Transform playerTarget)
    {
        _freeLook.m_Follow =_freeLook.m_LookAt = playerTarget;
    }

    public void ZoomCamera(float value)
    {
       DOTween.To(() => _freeLook.m_Lens.OrthographicSize, x => _freeLook.m_Lens.OrthographicSize = x, value, 1f);
    }
    
    
}
