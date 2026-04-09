using System;

namespace Other
{
    public class Animation : IAnimation
    {
        private readonly ReactiveValue<float> _animatedValue = new();
        private float _startValue;
        private float _endValue;
        private float _duration;
        private float _currentProgress;

        public IReactiveValue<float> AnimatedValue => _animatedValue;

        public Animation()
        {
            _startValue = 0;
            _endValue = 1;
            _duration = 1;
            _currentProgress = 0;
        }

        public void SetLimits(float startValue, float endValue)
        {
            _startValue = startValue;
            _endValue = endValue;
        }

        public void SetDuration(float time)
        {
            _duration = time;
        }

        public void SetProgress(float value)
        {
            value = Math.Clamp(value, 0, 1);
            _currentProgress = value;
            UpdateTarget();
        }

        public void NextStep(float deltaTime)
        {
            float frameStep = deltaTime / _duration;
            SetProgress(_currentProgress + frameStep);
        }

        private float GetLength()
        {
            return _endValue - _startValue;
        }

        private void UpdateTarget()
        {
            _animatedValue.Value = _startValue + GetLength() * _currentProgress;
        }
    }
}