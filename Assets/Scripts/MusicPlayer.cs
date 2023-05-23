using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip musicClip;
    private AudioSource audioSource;
    private bool isLooping = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.loop = false;
        audioSource.Play();
    }

    private void Update()
    {
        if (!audioSource.isPlaying && !isLooping)
        {
            isLooping = true;
            audioSource.time = 0;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
