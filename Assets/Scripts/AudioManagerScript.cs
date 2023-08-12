using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource _sfxSource;

    [Header("Audio Clips")]
    public AudioClip jump;
    public AudioClip point;
    public AudioClip death;

    public void PlaySFX(AudioClip audioClip)
    {
        _sfxSource.PlayOneShot(audioClip);
    }
}
