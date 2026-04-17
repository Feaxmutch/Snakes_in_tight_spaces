using Model;
using Other;

namespace ViewModel
{
    public class ColoredObjectVM : GridObjectVM
    {
        private readonly ReactiveValue<Color> _color = new();

        public ColoredObjectVM() : base() { }

        public IReactiveValue<Color> Color => _color;

        public void Initialize(Color color)
        {
            _color.Value = color;
        }

        protected void SetColor(Color color)
        {
            _color.Value = color;
        }
    }
}