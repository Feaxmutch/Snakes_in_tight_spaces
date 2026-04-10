using System;
using UnityEngine;
using ViewModel;

public class TimeEvent : MonoBehaviour, IGlobalEvent
{
    [SerializeField] private float _triggerTime;

    private float _time;
    private bool _invoked;

    public event Action Invoked;

    void Awake()
    {
        _invoked = false;
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _triggerTime && _invoked == false)
        {
            Invoked.Invoke();
            _invoked = true;
        }
    }
}