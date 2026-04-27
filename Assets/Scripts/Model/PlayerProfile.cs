namespace Model
{
    public class PlayerProfile : IPlayerProfile
    {
        public PlayerProfile(string name)
        {
            Name =  name;
            SetDefault();
        }

        public string Name { get; private set; }

        public int LastLevel { get; private set; }

        public int HatID { get; private set;}

        public int Score { get; private set; }

        public void SetLastLevel(int ID)
        {
            LastLevel = ID;
        }

        public void SetHat(int ID)
        {
            HatID = ID;
        }

        public void SetScore(int value)
        {
            Score = value;
        }

        private void SetDefault()
        {
            LastLevel = 1;
            HatID = 0;
            Score = 0;
        }
    }
}