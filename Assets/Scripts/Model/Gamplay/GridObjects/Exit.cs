using Other;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Exit : ColoredObject
    {
        private readonly ReactiveValue<bool> _isOpened = new();
        private Vector2Int _forwardDirection;

        public Exit() : base() { }

        public IReactiveValue<bool> IsOpened => _isOpened;

        public Vector2Int ForwardDirection => _forwardDirection;

        public void Initialize(Vector2Int forwardDirection)
        {
            _forwardDirection = forwardDirection.Normalized;
        }

        public override void OnStart()
        {
            base.OnStart();
            Level.CurrentLevel.Grid.ObjectRemoved += UpdateStatus;
        }

        public bool IsAplesExist()
        {
            List<Apple> apples = Level.CurrentLevel.Grid.GetObjectsOfType<Apple>();
            List<Apple> targetApples = apples.Where(apple => apple.Color == Color).ToList();
            return targetApples.Count > 0;
        }

        private void UpdateStatus()
        {
            _isOpened.Value = IsAplesExist() == false;
            SetSolid(_isOpened.Value == false);
        }
    }
}