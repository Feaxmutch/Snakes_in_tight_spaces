using Model;
using Other;
using System;
using UnityEngine;

namespace ViewModel
{
    public class GamemodeWindowVM : DefaultWindowVM
    {
        private ReactiveValue<string> _timerText = new();

        public GamemodeWindowVM() : base()
        {
            
        }

        public IReactiveValue<string> TimerText => _timerText;

        public void Initialize(DefaultGamemode gamemode)
        {
            gamemode.Timer.Changed += OnTimerChanged;
        }

        private void OnTimerChanged(float actualTime)
        {
            int minutes = (int)Mathf.Floor(actualTime / 60);
            int seconds = (int)(actualTime % 60);
            _timerText.Value = $"{minutes}:{seconds}";
        }
    }
}