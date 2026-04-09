using System;

namespace Model
{
    public interface IGamemode
    {
        event Action Started;
        event Action Paused;
        event Action Unpaused;
        event Action Ended;

        bool IsPaused { get; }

        void Pause();
        void Unpause();
    }
}