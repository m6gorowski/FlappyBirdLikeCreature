using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource musicSource;
    [SerializeField] private AudioSource _sfxSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip _backgroundMusic;
    public AudioClip jump;
    public AudioClip point;
    public AudioClip death;

    private void Start()
    {
        musicSource.clip = _backgroundMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip audioClip)
    {
        _sfxSource.PlayOneShot(audioClip);
    }
}
