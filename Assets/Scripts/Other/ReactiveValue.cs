using System;

namespace Other
{
    public class ReactiveValue<T> : IReactiveValue<T>
    {
        private T _value;

        public ReactiveValue(T value = default)
        {
            Value = value;
        }

        public event Action<T> Changed;

        public T Value { get => _value; set => SetValue(value); }

        public void Subscribe(IReactiveValue<T> reactiveValue)
        {
            reactiveValue.Changed += OnValueChanged;
            reactiveValue.InvokeEvent();
        }

        public void Unsubscribe(IReactiveValue<T> reactiveValue)
        {
            reactiveValue.Changed -= OnValueChanged;
        }

        public void InvokeEvent()
        {
            Changed?.Invoke(_value);
        }

        private void OnValueChanged(T value)
        {
            Value = value;
        }

        private void SetValue(T value)
        {
            if (_value == null || _value.Equals(value) == false)
            {
                _value = value;
                Changed?.Invoke(_value);
            }
        }
    }
}