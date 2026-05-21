using ViewModel;
using UnityEngine;

public class ExitV : ColoredObjectV
{
    private ExitVM _viewModel;
    private Vector3 _basePosition;

    private void Awake()
    {
        _basePosition = transform.position;
    }

    public void Initialize(ExitVM viewModel)
    {
        _viewModel = viewModel;
        _viewModel.YOffset.Changed += UpdateYOffset;
        UpdateYOffset(_viewModel.YOffset.Value);
    }

    protected override void Subscribe()
    {
        base.Subscribe();

        if (IsInitialized)
        {
            _viewModel.YOffset.Changed += UpdateYOffset;
        }
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();

        if (IsInitialized)
        {
            _viewModel.YOffset.Changed -= UpdateYOffset;
        }
    }

    private void UpdateYOffset(float value)
    {
        Vector3 newOffset = Vector3.up * (_basePosition.y + value);
        transform.position = _basePosition + newOffset;
    }
}