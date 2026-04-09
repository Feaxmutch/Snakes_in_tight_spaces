using System;

namespace ViewModel
{
    public interface IUnityUpdate
    {
        public event Action<float> Updated;
    }
}