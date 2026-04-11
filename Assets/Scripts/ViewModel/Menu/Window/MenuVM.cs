
namespace ViewModel
{
    public class MenuVM
    {
        private IWindowVM[] _windows;

        public MenuVM() { }

        public void Initialize(IWindowVM[] windows)
        {
            _windows = windows;
            SubscribeToWindows();
        }

        private void SubscribeToWindows()
        {
            foreach (var window in _windows)
            {
                SubscribeToButtons(window);
            }
        }

        private void SubscribeToButtons(IWindowVM window)
        {
            foreach (var button in window.Buttons)
            {
                SubscribeToButton(button);
            }
        }

        private void SubscribeToButton(IButton button)
        {
            button.Clicked += OnButtonClick;
        }

        private void OnButtonClick(IButtonAction[] actions)
        {
            foreach (var action in actions)
            {
                action.Perform();
            }
        }


    }
}