using System;

namespace Other
{
    public class Animation : IAnimation
    {
        private readonly ReactiveValue<float> _animatedValue = new();
        private ICurve _curve;
        private float _startValue;
        private float _endValue;
        private float _duration;
        private float _currentProgress;

        public IReactiveValue<float> AnimatedValue => _animatedValue;

        public float CurrentProgress => _currentProgress;

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

        public void SetDuration(float time) => _duration = time;

        public void SetProgress(float value)
        {
            if(value.IsInRange(0, 1) == false) throw new ArgumentOutOfRangeException("expected value between 0 and 1");
            _currentProgress = value;
            UpdateTarget();
        }

        public void SetCurve(ICurve curve) => _curve = curve;

        public void NextStep(float deltaTime)
        {
            float frameStep = deltaTime / _duration;
            SetProgress(Math.Clamp(_currentProgress + frameStep, 0, 1));
        }

        private float GetLength() => _endValue - _startValue;

        private void UpdateTarget()
        {
            float progress;

            if (_curve != null)
            {
                progress = _curve.Evaluate(_currentProgress);
            }
            else
            {
                progress = _currentProgress;
            }

            progress = Math.Clamp(progress, 0, 1);
            _animatedValue.Value = _startValue + GetLength() * progress;
        }
    }
}