namespace Model
{
    public interface ILevel
    {
        IGamemode Gamemode { get; }

        IGrid Grid { get; }
        
        void OnUpdate(float deltaTime);
    }
}