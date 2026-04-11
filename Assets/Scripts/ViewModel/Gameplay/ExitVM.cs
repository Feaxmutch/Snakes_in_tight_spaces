using Model;
using Other;
using Color = Other.Color;

namespace ViewModel
{
    public class ExitVM : ColoredObjectVM
    {
        private ReactiveValue<bool> _isOpened = new();

        public IReactiveValue<bool> IsOpened => _isOpened;

        public void Initialize(Color color, Exit exit)
        {
            base.Initialize(color, exit);
            _isOpened.Subscribe(exit.IsOpened);
            _isOpened.Value = exit.IsOpened.Value;
        }
    }
}