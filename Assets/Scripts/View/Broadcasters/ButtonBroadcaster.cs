using System;
using UnityEngine;
using UnityEngine.UI;
using ViewModel;

[RequireComponent(typeof(Button))]
public class ButtonBroadcaster : MonoBehaviour, IButtonBroadcaster
{
    private Button _button;

    public event Action Clicked;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(InvokeClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(InvokeClick);
    }

    private void InvokeClick()
    {
        Clicked.Invoke();
    }
}