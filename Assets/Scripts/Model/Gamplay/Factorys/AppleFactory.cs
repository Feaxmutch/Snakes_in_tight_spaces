using Other;

namespace Model
{
    public class AppleFactory : ColoredObjectFactory
    {
        public Apple Create(Color color, Apple locker = null)
        {
            Apple apple = Create<Apple>(color);
            apple.Initialize(locker);
            return apple;
        }

        public T Create<T>(Apple locker = null) where T : Apple, new()
        {
            T apple = Create<T>(new Color());
            apple.Initialize(locker);
            return apple;
        }
    }
}