using System.IO.Pipes;
using UnityEngine;
using ViewModel;

public abstract class WindowRooot<VM, V> : MonoBehaviour where VM : WindowVM, new() where V : WindowV
{
    [SerializeField] private bool _isVisibleOnStart;
    [SerializeField] private ButtonV[] _buttons;
    [SerializeField] private GlobalEvent[] _showEvents;
    [SerializeField] private GlobalEvent[] _hideEvents;

    [field : SerializeField] public V View { get; private set; } 
    
    public VM ViewModel {get; protected set; }

    public virtual void Compose()
    {
        ViewModel = new();
        InitViewModel();
        InitView();
    }

    protected virtual void InitViewModel()
    {
        ViewModel.Init(_buttons, _isVisibleOnStart);

        if (_showEvents == null)
        {
            _showEvents = new GlobalEvent[0];
        }

        if (_hideEvents == null)
        {
            _hideEvents = new GlobalEvent[0];
        }

        ViewModel.Subscribe(_showEvents, _hideEvents);
    }

    protected virtual void InitView()
    {
        View.Initialize(ViewModel);
    }
}