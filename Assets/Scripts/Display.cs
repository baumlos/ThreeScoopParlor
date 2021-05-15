using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    private const int MAX_ICE_CREAM_AMOUT = 3;
    [SerializeField] private Transform[] _scoops = new Transform[MAX_ICE_CREAM_AMOUT];
    private List<Icecream> _icecreams = new List<Icecream>();
    private int currentScoop;
    
    public bool Interactable { get => currentScoop < MAX_ICE_CREAM_AMOUT; }

    [SerializeField] private Button _nextOrderButton;
    [SerializeField] private TextMeshProUGUI _orderText;
    [SerializeField] private TextMeshProUGUI _resultText;

    private void Start()
    {
        _nextOrderButton.onClick.AddListener(NewOrder);
        NewOrder();
    }

    public void AddIcecream(Icecream icecreamPrefab)
    {
        var icecream = Instantiate(icecreamPrefab, _scoops[currentScoop], false);
        icecream.transform.localPosition = Vector3.zero;
        _icecreams.Add(icecream);

        if (++currentScoop >= MAX_ICE_CREAM_AMOUT)
            FinishOrder();
    }

    private void FinishOrder()
    {
        Debug.Log("TODO finish order");
        _nextOrderButton.gameObject.SetActive(true);
        _resultText.gameObject.SetActive(true);
        _resultText.text = GetResult(_icecreams);
    }
    
    // order loop logic
    private void NewOrder()
    {
        ResetIcecream();
        _nextOrderButton.gameObject.SetActive(false);
        _orderText.text = GenerateOrder();
        _resultText.gameObject.SetActive(false);
    }

    private void ResetIcecream()
    {
        currentScoop = 0;
        
        foreach (var icecream in _icecreams)
        {
            Destroy(icecream.gameObject);
        }
        _icecreams.Clear();
    }

    // order generation
    private string GenerateOrder()
    {
        Debug.Log("TODO generate new order");
        return "todo";
    }

    private string GetResult(List<Icecream> icecreams)
    {
        Debug.Log("TODO generate result text");
        return "A new exciting flavour!";
    }
}