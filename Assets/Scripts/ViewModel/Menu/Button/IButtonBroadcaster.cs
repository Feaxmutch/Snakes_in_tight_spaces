using System;

namespace ViewModel
{
    public interface IButtonBroadcaster

    {
        public event Action Clicked;
    }
}