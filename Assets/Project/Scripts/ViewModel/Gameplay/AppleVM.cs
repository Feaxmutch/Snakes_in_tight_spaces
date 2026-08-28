using Model;
using Other;

namespace ViewModel
{
    public class AppleVM : EntityVM
    {
        private readonly ReactiveValue<bool> _isLocked = new();
        private Apple _apple;

        public IReactiveValue<bool> IsLocked => _isLocked;

        public void Initialize(Apple apple)
        {
            _isLocked.Subscribe(apple.IsLocked);
            _apple = apple;
        }

        protected override void OnModelStart()
        {
            base.OnModelStart();
            _apple.IsLocked.InvokeEvent();
            IsLocked.InvokeEvent();
        }
    }
}