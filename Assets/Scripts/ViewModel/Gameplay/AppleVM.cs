using Model;
using Other;

namespace ViewModel
{
    public class AppleVM : ColoredObjectVM
    {
        private readonly ReactiveValue<bool> _isLocked = new();

        private Color _defaultColor;
        private Apple _apple;

        public IReactiveValue<bool> IsLocked => _isLocked;

        public void Initialize(Apple apple)
        {
            _isLocked.Subscribe(apple.IsLocked);
            _apple = apple;
            _defaultColor = Color.Value;
            _isLocked.Changed += OnLocked;
        }

        protected override void OnModelStart()
        {
            base.OnModelStart();
            _apple.IsLocked.InvokeEvent();
            IsLocked.InvokeEvent();
        }

        private void OnLocked(bool isLocked)
        {
            if (isLocked)
            {
                SetColor(Other.Color.Black);
            }
            else
            {
                SetColor(_defaultColor);
            }
        }
    }
}