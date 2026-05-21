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

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void OnApplicationQuit()
    {
        Unsubscribe();
    }

    public void Initialize(WindowVM viewModel)
    {
        if (_canvasGroup == null) Awake();
        _viewModel = viewModel;
        _viewModel.IsActive.Changed += OnActiveState;
        OnActiveState(_viewModel.IsActive.Value);
        Initialized = true;
    }

    protected virtual void Subscribe()
    {
        if (Initialized)
        {
            _viewModel.IsActive.Changed += OnActiveState;
        }
    }

    protected virtual void Unsubscribe()
    {
        if (Initialized)
        {
            _viewModel.IsActive.Changed -= OnActiveState;
        }
    }

    private void OnActiveState(bool value) => _canvasGroup.interactable = value;
}