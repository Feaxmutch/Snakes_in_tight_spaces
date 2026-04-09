using Other;

namespace Model
{
    public class ColoredObjectFactory : GridObjectFactory
    {
        public T Create<T>(Color color) where T : ColoredObject, new()
        {
            T createdObject = Create<T>();
            createdObject.Initialize(color);
            return createdObject;
        }
    }
}