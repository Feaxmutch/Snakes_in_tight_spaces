using System;
using UnityEngine;
using ViewModel;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonV : MonoBehaviour, IButton
{
    [SerializeField] private ButtonActionV[] _buttonActions;

    private Button _button;

    public event Action<IButtonAction[]> Clicked;

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
        Clicked?.Invoke(_buttonActions);
    }
}