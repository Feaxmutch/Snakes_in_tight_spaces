using System;
using System.Diagnostics;
using System.Threading;
using Cysharp.Threading.Tasks;
using Other;

namespace Model
{
    public class Level : ILevel
    {
        private static Level _currentLevel;
        private Gamemode _gamemode;
        private Grid _grid;
        private CancellationTokenSource _cts;

        public static event Action Started;
        public static event Action Stoping;

        public static ILevel CurrentLevel => _currentLevel;

        public IGamemode Gamemode => _gamemode;

        public IGrid Grid => _grid;

        public Level(Array2d<GridObject> objects, Gamemode gamemode)
        {
            _gamemode = gamemode;
            _grid = new();
            Initialize(objects);
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

            _currentLevel = level;
            level.OnStart();
            Started?.Invoke();
        }

        public static void Stop()
        {
            if (IsActive())
            {
                Stoping?.Invoke();
                _currentLevel.StopGamemode();
                _currentLevel.OnStop();
                _currentLevel = null;
            }
        }

        public void StopGamemode()
        {
            _gamemode.End();
        }

        public async UniTaskVoid LevelLoop(CancellationToken token)
        {
            var stopwatch = Stopwatch.StartNew();

            while (token.IsCancellationRequested == false)
            {
                stopwatch.Restart();
                await UniTask.Yield(token);
                OnUpdate((float)stopwatch.ElapsedMilliseconds / 1000);
            }
        }

        private void OnUpdate(float deltaTime)
        {
            _gamemode.OnFrameUpdated(deltaTime);
        }

        private void OnStart()
        {
            _grid.StartObjects();
            _gamemode.Start();
            _cts = new();
            LevelLoop(_cts.Token).Forget();
        }

        private void OnStop()
        {
            if (_cts != null)
            {
                _cts.Cancel();
                _cts.Dispose();
            }
            
        }

        private void Initialize(Array2d<GridObject> objects)
        {
            _grid.Initialize(objects);
        }
    }
}