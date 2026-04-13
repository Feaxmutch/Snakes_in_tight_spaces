using ViewModel;

public class DefaultGridObjectV : GridObjectV
{
    private GridObjectVM _viewModel;

    protected virtual void OnEnable()
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

    protected virtual void OnDisable()
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

    public void Initialize(GridObjectVM viewModel)
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
        Initialize();
    }
}