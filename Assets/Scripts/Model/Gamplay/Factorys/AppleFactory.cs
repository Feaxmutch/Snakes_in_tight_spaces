using Other;

namespace Model
{
    public class AppleFactory : EntityFactory
    {
        public Apple Create(byte groopId, Apple locker = null)
        {
            Apple apple = Create<Apple>(groopId);
            apple.Initialize(locker);
            return apple;
        }

        public T Createdd<T>(Apple locker = null) where T : Apple, new()
        {
            T apple = Create<T>(0);
            apple.Initialize(locker);
            return apple;
        }
    }
}