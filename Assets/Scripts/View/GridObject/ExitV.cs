using ViewModel;
using DG.Tweening;

public class ExitV : ColoredObjectV
{
    private ExitVM _viewModel;
    private float _openOffset = 1; 

    protected override void OnEnable()
    {
        base.OnEnable();

        if (IsInitialized)
        {
            _viewModel.IsOpened.Changed += UpdateOpenState;
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        if (IsInitialized)
        {
            _viewModel.IsOpened.Changed -= UpdateOpenState;
        }
    }

    public void Initialize(ExitVM viewModel)
    {
        _viewModel = viewModel;
        _viewModel.IsOpened.Changed += UpdateOpenState;
        UpdateOpenState(_viewModel.IsOpened.Value);
    }

    private void UpdateOpenState(bool isOpened)
    {
        if (isOpened)
        {
            transform.DOMoveY(transform.position.y + _openOffset, 1);
        }
    }
}