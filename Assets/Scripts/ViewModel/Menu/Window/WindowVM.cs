using System;
using Other;

namespace ViewModel
{
    public abstract class WindowVM : IWindowVM
    {
        private IButton[] _buttons;
        private IGlobalEvent _showEvents;
        private IGlobalEvent _hideEvents;
        private ReactiveValue<bool> _isActive = new();

        public IReactiveValue <bool> IsActive => _isActive;

        public WindowVM() { }

        public IButton[] Buttons => _buttons;

        public event Action Showed;
        public event Action Hided;

        public void Init(IButton[] buttons, bool isVisibleOnStart)
        {
            _isActive.Value = isVisibleOnStart;
            _buttons = buttons;
        }

        public void Subscribe(IGlobalEvent[] showEvents, IGlobalEvent[] hideEvents)
        {
            foreach (var showEvent in showEvents)
            {
                showEvent.Invoked += Show;
            }

            foreach (var hideEvent in hideEvents)
            {
                hideEvent.Invoked += Hide;
            }
        }

        public void Show()
        {
            _isActive.Value = true;
            Showed?.Invoke();
        }

        public void Hide()
        {
            _isActive.Value = false;
            Hided?.Invoke();
        }
    }
}