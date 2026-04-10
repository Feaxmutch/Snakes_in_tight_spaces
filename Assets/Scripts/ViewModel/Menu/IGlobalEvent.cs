using System;

namespace ViewModel
{
    public interface IGlobalEvent
    {
        event Action Invoked;
    }
}