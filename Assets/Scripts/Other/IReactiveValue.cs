using System;

namespace Other
{
    public interface IReactiveValue<T>
    {
        public event Action<T> Changed;

        public T Value { get; }

        public void InvokeEvent();
    }
}