using UnityEngine;
using ViewModel;

[RequireComponent(typeof(CanvasGroup))]
public abstract class WindowV : MonoBehaviour
{
    private WindowVM _viewModel;
    
    protected CanvasGroup CanvasGroup { get; private set; }

    public IWindowVM ViewModel => _viewModel;
    
    public bool Initialized { get; private set; } = false;

    protected virtual void Awake()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
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
        if (CanvasGroup == null) Awake();
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

    private void OnActiveState(bool value) => CanvasGroup.interactable = value;
}