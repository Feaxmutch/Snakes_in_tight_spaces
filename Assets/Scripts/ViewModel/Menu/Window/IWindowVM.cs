namespace ViewModel
{
    public interface IWindowVM
    {
        public IButton[] Buttons { get; }

        public void Show();
        public void Hide();
    }
}