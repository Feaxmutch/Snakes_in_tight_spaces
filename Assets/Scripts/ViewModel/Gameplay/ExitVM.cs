using Model;
using Other;
using Color = Other.Color;

namespace ViewModel
{
    public class ExitVM : ColoredObjectVM
    {
        private Animator _animator;
        private Animation _openAnimation;
        private Animation _closeAnimation;

        private ReactiveValue<bool> _isOpened = new();

        private ReactiveValue<float> _yOffset = new();

        public IReactiveValue<float> YOffset => _yOffset;

        public void Initialize(Exit exit, Animation openAnimation, Animation closeAnimation, IUnityUpdate unityUpdate)
        {
            _animator = new(unityUpdate);
            _openAnimation = openAnimation;
            _closeAnimation = closeAnimation;
            Subscribe(exit);
            PlayAnimation(_isOpened.Value);
            _animator.SkipToEnd();
        }

        private void Subscribe(Exit exit)
        {
            _isOpened.Subscribe(exit.IsOpened);
            _isOpened.Value = exit.IsOpened.Value;
            _isOpened.Changed += PlayAnimation;
            _yOffset.Subscribe(_openAnimation.AnimatedValue);
            _yOffset.Subscribe(_closeAnimation.AnimatedValue);
        }

        private void PlayAnimation(bool isOpened)
        {
            if (isOpened)
            {
                _animator.SetAnimation(_openAnimation);
            }
            else
            {
                _animator.SetAnimation(_closeAnimation);
            }

            _animator.Play();
        }
    }
}