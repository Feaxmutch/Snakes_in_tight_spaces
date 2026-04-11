using System;
using UnityEngine;
using ViewModel;

public class ButtonV : MonoBehaviour, IButton
{
    [SerializeField] private ButtonBroadcaster _broadcaster;
    [SerializeField] private ButtonActionV[] _buttonActions;

    public event Action<IButtonAction[]> Clicked;

    private void OnEnable()
    {
        _broadcaster.Clicked += InvokeClick;
    }

    private void OnDisable()
    {
        _broadcaster.Clicked -= InvokeClick;
    }

    private void InvokeClick()
    {
        Clicked?.Invoke(_buttonActions);
    }
}