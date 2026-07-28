using Model;
using Other;

namespace ViewModel
{
    public class ExitVM : EntityVM
    {
        private Animator _animator;
        private Animation _openAnimation;
        private Animation _closeAnimation;

        private ReactiveValue<bool> _isOpened = new();

        private ReactiveValue<float> _doorOffset = new();

        public IReactiveValue<float> DoorOffset => _doorOffset;

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
            _doorOffset.Subscribe(_openAnimation.AnimatedValue);
            _doorOffset.Subscribe(_closeAnimation.AnimatedValue);
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