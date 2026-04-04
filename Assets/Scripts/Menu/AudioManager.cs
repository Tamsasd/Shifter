using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--- Audio Source ---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("--- Audio Clip ---")]
    public AudioClip backgroundMusic;
    public AudioClip click;
    public AudioClip death;
    // etc...

    void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    // use this for all future sounds
    public void PlaySFX(AudioClip sound)
    {
        SFXSource.PlayOneShot(sound);
    }

    void Update()
    {
        
    }
}
