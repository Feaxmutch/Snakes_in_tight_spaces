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

    protected virtual void OnAnimationChanged(float currentState){}
}