using System;
using Cinemachine;
using UnityEngine;


public class CameraManager : MonoSingleton<CameraManager>
{
    [SerializeField] private CinemachineVirtualCamera _freeLook;

    public void UpdateTarget(Transform playerTarget)
    {
        _freeLook.m_Follow =_freeLook.m_LookAt = playerTarget;
    }
}
