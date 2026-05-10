using ViewModel;

public class AnimatedWindowV : WindowV
{
    private AnimatedWindowVM _viewModel;

    private void OnEnable()
    {
        if (Initialized)
        {
            _viewModel.AnimatedValue.Changed += OnAnimationChanged;
        }
    }

    private void OnDisable()
    {
        if (Initialized)
        {
            _viewModel.AnimatedValue.Changed -= OnAnimationChanged;
        }
    }

    public void Init(AnimatedWindowVM viewModel)
    {
        _viewModel = viewModel;
        _viewModel.AnimatedValue.Changed += OnAnimationChanged;
        OnAnimationChanged(_viewModel.AnimatedValue.Value);
    }

    protected virtual void OnAnimationChanged(float currentState){}
}