namespace Model
{
    public interface IPlayerProfile
    {
        string Name { get; }

        int LastLevel { get; }

        int HatID { get; }

        int Score { get; }
    }
}