using UnityEngine;
using ViewModel;

public abstract class WindowV : MonoBehaviour
{
    private WindowVM _viewModel;

    public IWindowVM ViewModel => _viewModel;

    public bool Initialized { get; private set; } = false;

    public void Initialize(WindowVM viewModel)
    {
        _viewModel = viewModel;
        Initialized = true;
    }
}