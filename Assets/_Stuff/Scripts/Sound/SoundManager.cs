using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioClip backgroundMusic;
    private AudioSource audioSource;
    
    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();

        if (backgroundMusic != null)
        {
            audioSource.PlayOneShot(backgroundMusic);
        }
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
