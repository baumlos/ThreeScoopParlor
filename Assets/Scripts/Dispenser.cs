using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Linq;

public class Dispenser : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Icecream _icecream;
    [SerializeField] private AudioClip[] _plopSounds;
    private int _plopIndex;
    
    private IcecreamDisplay _icecreamDisplay;
    private AudioSource _audioSource;

    private void Awake()
    {
        _icecreamDisplay = FindObjectOfType<IcecreamDisplay>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _plopSounds = RandomizeArray(_plopSounds);
    }

    private AudioClip[] RandomizeArray(AudioClip[] array)
    {
        System.Random rnd = new System.Random();
        return array.OrderBy(x => rnd.Next()).ToArray();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_icecreamDisplay.Interactable) 
            return;
        
        _icecreamDisplay.AddIcecream(_icecream);
        _audioSource.clip = _plopSounds[_plopIndex];
        _audioSource.Play();
        _plopIndex = (_plopIndex + 1) % _plopSounds.Length;
    }
}
