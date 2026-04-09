using Other;
using System;

namespace Model
{
    public class ColoredObject : GridObject
    {
        public ColoredObject()
        {
            IsInitialized = false;
        }

        public bool IsInitialized { get; private set; }

        public Color Color { get; private set; }

        public virtual void Initialize(Color color)
        {
            if (IsInitialized)
            {
                throw new InvalidOperationException("Colored object is allready initialized (doble initializing)");
            }

            Color = color;
            IsInitialized = true;
        }
    }
}