using System;

namespace ViewModel
{
    public abstract class WindowVM : IWindowVM
    {
        private IButton[] _buttons;
        private IGlobalEvent _showEvents;
        private IGlobalEvent _hideEvents;

        protected bool IsActive {get; private set; }

        public WindowVM() { }

        public IButton[] Buttons => _buttons;

        public event Action Showed;
        public event Action Hided;

        public void Init(IButton[] buttons, bool isVisibleOnStart)
        {
            IsActive = isVisibleOnStart;
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
            IsActive = true;
            Showed?.Invoke();
        }

        public void Hide()
        {
            IsActive = false;
            Hided?.Invoke();
        }
    }
}