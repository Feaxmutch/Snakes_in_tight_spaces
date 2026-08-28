using System;
using Model;

namespace ViewModel
{
    public class LevelBroadcaster
    {
        public event Action Started;

        public void Initialize()
        {
            Level.Started += OnStart;
        }

        private void OnStart()
        {
            Started?.Invoke();
        }
    }
}