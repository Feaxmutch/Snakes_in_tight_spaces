using UnityEngine;
using ViewModel;

[RequireComponent(typeof(CanvasGroup))]
public abstract class WindowV : MonoBehaviour
{
    private WindowVM _viewModel;
    private CanvasGroup _canvasGroup;

    public IWindowVM ViewModel => _viewModel;

    public bool Initialized { get; private set; } = false;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Initialize(WindowVM viewModel)
    {
        if (_canvasGroup == null) Awake();
        _viewModel = viewModel;
        _viewModel.IsActive.Changed += OnActiveState;
        OnActiveState(_viewModel.IsActive.Value);
        Initialized = true;
    }

    private void OnActiveState(bool value) => _canvasGroup.interactable = value;
}