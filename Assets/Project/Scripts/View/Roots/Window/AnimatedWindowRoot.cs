using UnityEngine;
using ViewModel;
using Animation = Other.Animation;

public abstract class AnimatedWindowRoot<VM, V> : WindowRooot<VM, V> where VM : AnimatedWindowVM, new() where V : AnimatedWindowV
{
    [SerializeField] private AnimationData _showData;
    [SerializeField] private AnimationData _hideData;

    private Animation _showAnimation;
    private Animation _hideAnimation;
    private AnimationFactory _animationFactory;

    protected override void InitViewModel()
    {
        base.InitViewModel();
        _animationFactory = new();
        _showAnimation = _animationFactory.Create(_showData);
        _hideAnimation = _animationFactory.Create(_hideData);
        ViewModel.Init(_showAnimation, _hideAnimation);
    }

    protected override void InitView()
    {
        base.InitView();
        View.Init(ViewModel);
    }
}