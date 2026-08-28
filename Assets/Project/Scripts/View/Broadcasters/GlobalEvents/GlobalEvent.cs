using System;
using UnityEngine;
using ViewModel;

public abstract class GlobalEvent : MonoBehaviour, IGlobalEvent
{
    public event Action Invoked;

    protected void OnInvoke()
    {
        Invoked?.Invoke();
    }
}