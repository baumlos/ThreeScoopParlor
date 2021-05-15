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
        Debug.Log($"Selected icecream: {_icecream.Name}");
    }
}
