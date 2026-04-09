namespace Model
{
    public class GridObjectFactory
    {
        public T Create<T>() where T : GridObject, new()
        {
            return new T();
        }
    }
}