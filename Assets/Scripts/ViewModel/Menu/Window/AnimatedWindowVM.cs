using Other;
using Animation = Other.Animation;

namespace ViewModel
{
    public abstract class AnimatedWindowVM : WindowVM
    {
        private Animator _animator;
        private Animation _showAnimation;
        private Animation _hideAnimation;

        protected IAnimation ShowAnimation => _showAnimation;
        protected IAnimation HideAnimation => _hideAnimation;

        public void Init(Animation showAnimation, Animation hideAnimation, IUnityUpdate unityUpdate)
        {
            _animator = new(unityUpdate);
            _showAnimation = showAnimation;
            _hideAnimation = hideAnimation;
            Subscribe();
            InitAnimationState();
        }

        private void Subscribe()
        {
            Showed += OnShow;
            Hided += OnHide;
        }

        private void InitAnimationState()
        {
            if(IsActive)
            {
                _animator.SetAnimation(_showAnimation);
            }
            else
            {
                _animator.SetAnimation(_hideAnimation);
            }

            _animator.SkipToEnd();
        }

        private void OnShow()
        {
            _animator.SetAnimation(_showAnimation);
            _animator.Play();
        }

        private void OnHide()
        {
            _animator.SetAnimation(_hideAnimation);
            _animator.Play();
        }
    }
}