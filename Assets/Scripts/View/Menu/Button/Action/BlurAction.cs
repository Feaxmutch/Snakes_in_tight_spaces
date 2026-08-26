using UnityEngine;
using Animator = ViewModel.Animator;
using Animation = Other.Animation;
using Other;


public class BlurActionV : ButtonActionV
{
    [SerializeField] private DepthOfFieldService _service;
    [SerializeField] private AnimationData _animationData;
    private Animator _animator = new();
    private Animation _animation;
    private AnimationFactory _animationFactory = new();
    private ReactiveValue<float> _blurValue = new();

    private void Awake()
    {
        _animation = _animationFactory.Create(_animationData);
        _blurValue.Subscribe(_animation.AnimatedValue);
        _animator.SetAnimation(_animation);
        _blurValue.Changed += EffectValueChanged;
        EffectValueChanged(32f);
    }

    public override void Perform()
    {
        _animator.Play();
    }

    private void EffectValueChanged(float value)
    {
        _service.SetValue(value);
    }
}
