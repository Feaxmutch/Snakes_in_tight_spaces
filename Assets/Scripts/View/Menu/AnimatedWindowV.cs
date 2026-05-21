using ViewModel;

public class AnimatedWindowV : WindowV
{
    private AnimatedWindowVM _viewModel;

    public void Init(AnimatedWindowVM viewModel)
    {
        _viewModel = viewModel;
        _viewModel.AnimatedValue.Changed += OnAnimationChanged;
        OnAnimationChanged(_viewModel.AnimatedValue.Value);
    }

    protected override void Subscribe()
    {
        base.Subscribe();

        if (Initialized)
        {
            _viewModel.AnimatedValue.Changed += OnAnimationChanged;
        }
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();

        if (Initialized)
        {
            _viewModel.AnimatedValue.Changed -= OnAnimationChanged;
        }
    }

    protected virtual void OnAnimationChanged(float currentState){}
}