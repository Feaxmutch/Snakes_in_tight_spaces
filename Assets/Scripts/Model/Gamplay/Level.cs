using System;
using Other;

namespace Model
{
    public class Level
    {
        private Gamemode _gamemode;
        private Grid _grid;

        public static event Action Started;

        public static Level CurrentLevel { get; private set; }

        public IGamemode Gamemode => _gamemode;

        public IGrid Grid => _grid;

        public Level(Array2d<GridObject> objects, Gamemode gamemode)
        {
            _gamemode = gamemode;
            _grid = new();
            Initialize(objects);
        }

        public void Initialize(Array2d<GridObject> objects)
        {
            _grid.Initialize(objects);
        }

        public static bool IsActive()
        {
            return CurrentLevel != null;
        }

        public static void Start(Level level)
        {
            if (IsActive())
            {
                throw new Exception("Level is allready active. Stop the current level before starting a new level");
            }

            CurrentLevel = level;
            level.OnStart();
            Started?.Invoke();
        }

        public static void Stop()
        {
            if (IsActive())
            {
                CurrentLevel = null;
            }
        }

        public void OnUpdate(float deltaTime)
        {
            _gamemode.OnFrameUpdated(deltaTime);
        }

        private void OnStart()
        {
            _grid.StartObjects();
            _gamemode.Start();
        }
    }
}