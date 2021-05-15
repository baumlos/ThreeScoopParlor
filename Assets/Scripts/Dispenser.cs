using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Dispenser : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Icecream _icecream;
    private Display _display;

    private void Awake()
    {
        _display = FindObjectOfType<Display>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(_display.Interactable)
            _display.AddIcecream(_icecream);
    }
}
