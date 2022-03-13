using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footStep : MonoBehaviour
{
    [SerializeField]private AudioSource source;
    [SerializeField] private AudioClip footstep;
    public void PlayFootStepAudio()
    {
        AudioManager.instance.PlaySoundWithAudioSource(source,footstep);
    }
}
