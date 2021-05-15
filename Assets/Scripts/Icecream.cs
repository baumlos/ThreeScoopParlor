using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class Icecream : MonoBehaviour
{
    public string Name;
    public string[] First;
    public string[] Middle;
    public string[] Last;
    public enum FlavourColor
    {
        White,
        Red,
        Yellow,
        Blue,
        Green
    }
    public FlavourColor Color;

    public enum FlavourMood
    {
        Anger,
        Fear,
        Sad,
        Sexy, 
        Joy
    }
    public FlavourMood Mood;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(float offset)
    {
        StartCoroutine(PlaySoundCoroutine(offset));
    }

    private IEnumerator PlaySoundCoroutine(float offset)
    {
        yield return new WaitForSeconds(offset);
        _audioSource.Play();
    }
}
