using Other;
using System;

namespace Model
{
    public class Entity : GridObject
    {
        public byte GroopId { get; private set; }

        public virtual void Initialize(byte groopId)
        {
            GroopId = groopId;
        }
    }
}