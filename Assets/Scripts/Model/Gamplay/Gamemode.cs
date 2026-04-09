using System;

namespace Model
{
    public abstract class Gamemode : IGamemode
    {
        public Gamemode()
        {
            IsPaused = true;
        }

        public event Action Started;
        public event Action Paused;
        public event Action Unpaused;
        public event Action Ended;

        public bool IsPaused { get; private set; }

        public void Start()
        {
            IsPaused = false;
            Started?.Invoke();
        }

        public void Pause()
        {
            IsPaused = true;
            Paused?.Invoke();
        }

        public void Unpause()
        {
            IsPaused = false;
            Unpaused?.Invoke();
        }

        public void End()
        {
            IsPaused = true;
            Ended?.Invoke();
        }

        public virtual void OnFrameUpdated(float deltaTime) { }

        public virtual void OnStart() { }
    }
}