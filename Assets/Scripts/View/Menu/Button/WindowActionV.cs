
using UnityEngine;
using ViewModel;

public abstract class WindowActionV : ButtonActionV
{
    [SerializeField] private WindowV _targetWindow;

    protected IWindowVM TargetWindow => _targetWindow.ViewModel;

    public override abstract void Perform();
}