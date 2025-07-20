using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private AudioSource audioSource;
    
    private void Awake()
    {
        if(Instance != null) Destroy(Instance.gameObject);
        Instance = this;

        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
