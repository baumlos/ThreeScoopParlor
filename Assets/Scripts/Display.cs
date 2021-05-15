using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    private const int MAX_ICE_CREAM_AMOUT = 3;
    [SerializeField] private Transform[] _scoops = new Transform[MAX_ICE_CREAM_AMOUT];
    private Icecream[] _icecreams = new Icecream[MAX_ICE_CREAM_AMOUT];
    private int currentScoop;

    public void AddIcecream(Icecream icecreamPrefab)
    {
        var icecream = Instantiate(icecreamPrefab, _scoops[currentScoop], false);
        icecream.transform.localPosition = Vector3.zero;
        _icecreams[currentScoop] = icecream;
        
        if(++currentScoop >= MAX_ICE_CREAM_AMOUT)
            FinishOrder();
    }

    private void FinishOrder()
    {
        Debug.Log("TODO finish order");
        
        currentScoop = 0;
        // foreach (var icecream in _icecreams)
        // {
        //     Destroy(icecream.gameObject);
        // }
    }

    private void GenerateOrder()
    {
        Debug.Log("TODO generate new order");
    }
}
