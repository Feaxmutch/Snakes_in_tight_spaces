using UnityEngine;
using ViewModel;
using Animation = Other.Animation;

public abstract class AnimatedWindowRoot<VM, V> : WindowRooot<VM, V> where VM : AnimatedWindowVM, new() where V : WindowV
{
    [SerializeField] private AnimationData _showData;
    [SerializeField] private AnimationData _hideData;
    [SerializeField] private UpdateBroadcaster _updateBroadcaster;

    private Animation _showAnimation;
    private Animation _hideAnimation;

    public override void Compose()
    {
        base.Compose();
    }

    protected override void InitViewModel()
    {
        base.InitViewModel();
        _showAnimation = new();
        _hideAnimation = new();
        InitAnimations();
        ViewModel.Init(_showAnimation, _hideAnimation, _updateBroadcaster);
    }

    protected override void InitView()
    {
        base.InitView();
        View.Initialize(ViewModel);
    }

    private void InitAnimations()
    {
        _showAnimation.SetLimits(_showData.StartValue, _showData.EndValue);
        _hideAnimation.SetLimits(_hideData.StartValue, _hideData.EndValue);
        _showAnimation.SetDuration(_showData.Duration);
        _hideAnimation.SetDuration(_showData.Duration);
    }
}