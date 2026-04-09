using Other;
using System;

namespace ViewModel
{
    public abstract class WindowVM : IWindowVM
    {
        private IButton[] _buttons;

        protected bool IsActive {get; private set; }

        public WindowVM() { }

        public IButton[] Buttons => _buttons;

        public event Action Showed;
        public event Action Hided;

        public void Init(IButton[] buttons, bool isVisibleOnStart)
        {
            IsActive = isVisibleOnStart;
            _buttons = buttons;

            if (isVisibleOnStart)
            {
                Show();
            }
            else
            {
                Hide();
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