using System;

namespace ViewModel
{
    public interface IButton
    {
        event Action<IButtonAction[]> Clicked;
    }
}