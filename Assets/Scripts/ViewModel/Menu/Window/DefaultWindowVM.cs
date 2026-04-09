using Other;

namespace ViewModel
{
    public class DefaultWindowVM : AnimatedWindowVM
    {
        private ReactiveValue<float> _positionY = new();

        public IReactiveValue<float> PositionY => _positionY;

        public DefaultWindowVM() : base()
        {
            
        }

        public void Init()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            _positionY.Subscribe(ShowAnimation.AnimatedValue);
            _positionY.Subscribe(HideAnimation.AnimatedValue);
        }
    }
}