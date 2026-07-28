using Other;

namespace Model
{
    public class EntityFactory : GridObjectFactory
    {
        public T Create<T>(byte groopId) where T : Entity, new()
        {
            T createdObject = Create<T>();
            createdObject.Initialize(groopId);
            return createdObject;
        }
    }
}