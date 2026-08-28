namespace Model
{
    public interface ILevel
    {
        IGamemode Gamemode { get; }

        IGrid Grid { get; }
    }
}