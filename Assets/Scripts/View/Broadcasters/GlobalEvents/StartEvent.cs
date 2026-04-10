using System;
using UnityEngine;
using ViewModel;

public class StartEvent : MonoBehaviour, IGlobalEvent
{
    private LevelBroadcaster _broadcaster;

    public event Action Invoked;

    private void Awake()
    {
        _broadcaster = new();
        _broadcaster.Initialize();
    }

    private void OnEnable()
    {
        _broadcaster.Started += OnStart;
    }

    private void OnDisable()
    {
        _broadcaster.Started -= OnStart;
    }

    private void OnStart()
    {
        Invoked?.Invoke();
    }
}