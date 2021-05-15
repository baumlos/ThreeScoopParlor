using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Dispenser : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Icecream _icecream;
    private IcecreamDisplay _icecreamDisplay;

    private void Awake()
    {
        _icecreamDisplay = FindObjectOfType<IcecreamDisplay>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(_icecreamDisplay.Interactable)
            _icecreamDisplay.AddIcecream(_icecream);
    }
}
