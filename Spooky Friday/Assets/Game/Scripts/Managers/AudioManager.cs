using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sounds[] sounds;

    public AudioSource Source;

    [SerializeField] private float volumeforRandomSfx;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

  
    public void Play(string sound)
    {
        Debug.Log("Audio of name  " + sound + " is played");
        
        Sounds s = Array.Find(sounds, item => item.name == sound);

        Source.loop = s.loop;
        Source.clip = s.clip;
        Source.volume = s.volum;
        Source.pitch = s.pitch;
        Source.Play();
        
    }
    public void Play(string sound1,string sound2,bool playConsecutive)
    {
        Sounds s1 = Array.Find(sounds, item => item.name == sound1);
        
        Source.clip = s1.clip;
        Source.volume = s1.volum;
        Source.pitch = s1.pitch;
        Source.Play();
        StartCoroutine(WaitForSound(sound2));
    }

    private IEnumerator WaitForSound(string sound2)
    {
        yield return new WaitUntil(() => Source.isPlaying == false);
        // or yield return new WaitWhile(() => audiosource.isPlaying == true);
        Sounds s2 = Array.Find(sounds, item => item.name == sound2);
        Source.clip = s2.clip;
        Source.volume = s2.volum;
        Source.pitch = s2.pitch;
        Source.loop = s2.loop;
        Source.Play();
    }
    public void PlayRandomSounds(AudioClip[] clip)
    {
        Source.volume = volumeforRandomSfx;
        Source.pitch = 1f;
        Source.PlayOneShot(clip[Random.Range(0, clip.Length)]);
    }

    public void PlaySoundWithAudioSource(AudioSource audioSource, AudioClip audioClip,bool play)
    {
        if (play)
            audioSource.PlayOneShot(audioClip);
        else
            audioSource.Stop();
    }

    public void PlayRandomSoundWithAudioSource(AudioSource audioSource, AudioClip[] clips)
    {
        audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
    
}