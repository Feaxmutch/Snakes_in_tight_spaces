using Other;

namespace Model
{
    public class Apple : ColoredObject
    {
        private readonly ReactiveValue<bool> _isLocked = new();

        private Apple _locker;

        public Apple() { }

        public IReactiveValue<bool> IsLocked
        {
            get 
            {
                UpdateLock();
                return _isLocked;
            }   
        }

        public void Initialize(Apple locker = null)
        {
            _locker = locker;

            if (locker != null)
            {
                locker.Destroyed += UpdateLock;
            }

            SetSolid(false);
        }

        public override void OnStart()
        {
            base.OnStart();
            UpdateLock();
        }

        private void UpdateLock()
        {
            _isLocked.Value = _locker != null && _locker.IsInLevel();
        }
    }
}