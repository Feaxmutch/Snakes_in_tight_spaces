using System.IO.Pipes;
using UnityEngine;
using ViewModel;

public abstract class WindowRooot<VM, V> : MonoBehaviour where VM : WindowVM, new() where V : WindowV
{
    [SerializeField] private bool _isVisibleOnStart;
    [SerializeField] private ButtonV[] _buttons;

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
    }

    protected virtual void InitView()
    {
        View.Initialize(ViewModel);
    }
}