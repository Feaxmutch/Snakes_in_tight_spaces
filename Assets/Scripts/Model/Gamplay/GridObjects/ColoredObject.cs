using Other;
using System;

namespace Model
{
    public class ColoredObject : GridObject
    {
        public Color Color { get; private set; }

        public virtual void Initialize(Color color)
        {
            Color = color;
        }
    }
}