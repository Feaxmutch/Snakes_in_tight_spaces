using ViewModel;

public class DefaultGridObjectV : GridObjectV
{
    private GridObjectVM _viewModel;

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

    public void Initialize(GridObjectVM viewModel, byte chapterId)
    {
        _viewModel = viewModel;

        if (_viewModel.IsUseInterpolation)
        {
            _viewModel.InterpolatedPosition.Changed += UpdatePosition;
            UpdatePosition(_viewModel.InterpolatedPosition.Value);
        }
        else
        {
            _viewModel.ModelPosition.Changed += UpdatePosition;
            UpdatePosition(_viewModel.ModelPosition.Value);
        }

        _viewModel.Destroyed += OnDestroyed;
        Initialize(chapterId);
    }

    protected virtual void Subscribe()
    {
        if (IsInitialized)
        {
            if (_viewModel.IsUseInterpolation)
            {
                _viewModel.InterpolatedPosition.Changed += UpdatePosition;
            }
            else
            {
                _viewModel.ModelPosition.Changed += UpdatePosition;
            }

            _viewModel.Destroyed += OnDestroyed;
        }
    }

    protected virtual void Unsubscribe()
    {
        if (IsInitialized)
        {
            if (_viewModel.IsUseInterpolation)
            {
                _viewModel.InterpolatedPosition.Changed -= UpdatePosition;
            }
            else
            {
                _viewModel.ModelPosition.Changed -= UpdatePosition;
            }

            _viewModel.Destroyed -= OnDestroyed;
        }
    }
}