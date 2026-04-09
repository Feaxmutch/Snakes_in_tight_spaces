using Other;
using UnityEngine;

namespace ViewModel
{
    public interface IUserInput
    {
        public Vector2 MousePosition { get; }

        public bool IsMouseHold { get; }
    }
}