using System;
using System.Collections.Generic;
using System.Linq;
using Other;

namespace Model
{
    public class PlayerProfile : IPlayerProfile
    {
        private List<int> _levelRecords = new();

        public PlayerProfile(string name)
        {
            Name =  name;
            SetDefault();
        }

        public string Name { get; private set; }

        public int HatID { get; private set;}

        public int Score => LevelRecords.Sum();

        public IReadOnlyList<int> LevelRecords => _levelRecords;

        public int LastOpenedLevel => _levelRecords.IndexOf(_levelRecords.Last());

        public void SetHat(int ID)
        {
            if(ID.IsNegative()) throw new ArgumentOutOfRangeException(nameof(ID), "id не может быть отрицательным");
            HatID = ID;
        }

        private void SetDefault()
        {
            HatID = 0;
            _levelRecords.Clear();
            _levelRecords.Add(0);
        }
    }
}