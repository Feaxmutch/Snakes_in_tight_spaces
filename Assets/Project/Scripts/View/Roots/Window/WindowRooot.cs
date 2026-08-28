using UnityEngine;
using ViewModel;

[System.Serializable]
public abstract class WindowRooot<VM, V> : BaseWindowRoot where VM : WindowVM, new() where V : WindowV
{
    [SerializeField] private bool _isVisibleOnStart;
    [SerializeField] private ButtonV[] _buttons;
    [SerializeField] private GlobalEvent[] _showEvents;
    [SerializeField] private GlobalEvent[] _hideEvents;

    private VM _windowVM;

    [field : SerializeField] public V View { get; private set; }

    public override IWindowVM BaseViewModel => _windowVM;

    public VM ViewModel {get { return _windowVM; } protected set { _windowVM = value; } }

    public override void Compose()
    {
        CreateAll();
        InitAll();
    }

    protected virtual void CreateAll()
    {
        if(ViewModel == null) ViewModel = CreateViewModel<VM>();
    }

    protected T CreateViewModel<T>() where T : WindowVM, new()
    {
        return new T();
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

    private void InitAll()
    {
        InitViewModel();
        InitView();
    }
}