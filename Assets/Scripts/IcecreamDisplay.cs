using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IcecreamDisplay : MonoBehaviour
{
    private static readonly int ANIM_PRESENTING = Animator.StringToHash("Presentation");
    
    private const int MAX_ICE_CREAM_AMOUNT = 3;
    [SerializeField] private Transform[] _scoops = new Transform[MAX_ICE_CREAM_AMOUNT];
    [SerializeField] private float[] _combinedSoundOffset = new float[MAX_ICE_CREAM_AMOUNT];
    [SerializeField] private float _moveForwardAmount = 2f;
    [SerializeField] private float _moveForwardSpeed = 2f;
    
    private List<Icecream> _icecreams = new List<Icecream>();
    private int _currentScoop;
    
    public bool Interactable { get => _currentScoop < MAX_ICE_CREAM_AMOUNT; }

    [SerializeField] private Button _nextOrderButton;
    [SerializeField] private TextMeshProUGUI _orderText;
    [SerializeField] private TextMeshProUGUI _resultText;

    private Animator _animator;
    private FlavourGenerator _flavourGenerator;
    private Transform _transform;
    private Vector3 _originalPosition;

    private void Awake()
    {
        _flavourGenerator = FindObjectOfType<FlavourGenerator>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _originalPosition = _transform.position;
        _nextOrderButton.onClick.AddListener(NewOrder);
        NewOrder();
    }

    private void Update()
    {
        // return if we are currently not in presentation mode
        if (Interactable) return;
        
        if (_transform.position.z >= _originalPosition.z - _moveForwardAmount)
        {
            _transform.Translate(Vector3.back * (_moveForwardSpeed * Time.deltaTime));
        }
    }

    public void AddIcecream(Icecream icecreamPrefab)
    {
        var icecream = Instantiate(icecreamPrefab, _scoops[_currentScoop], false);
        icecream.transform.localPosition = Vector3.zero;
        _icecreams.Add(icecream);

        if (++_currentScoop >= MAX_ICE_CREAM_AMOUNT)
            FinishOrder();
    }

    private void FinishOrder()
    {
        // ui
        _nextOrderButton.gameObject.SetActive(true);
        _resultText.gameObject.SetActive(true);
        _resultText.text = _flavourGenerator.GetResult(_icecreams);
        
        // anim
        _animator.SetBool(ANIM_PRESENTING, true);
        
        for (var i = 0; i < _icecreams.Count; i++)
        {
            _icecreams[i].PlaySound(_combinedSoundOffset[i]);
        }
        
        
    }

    // order loop logic
    private void NewOrder()
    {
        ResetIcecream();
        _nextOrderButton.gameObject.SetActive(false);
        _orderText.text = _flavourGenerator.GenerateOrder();
        _resultText.gameObject.SetActive(false);
    }

    private void ResetIcecream()
    {
        _currentScoop = 0;
        _transform.position = _originalPosition;
        
        // anim
        _animator.SetBool(ANIM_PRESENTING, false);
        
        foreach (var icecream in _icecreams)
        {
            Destroy(icecream.gameObject);
        }
        _icecreams.Clear();
    }
}