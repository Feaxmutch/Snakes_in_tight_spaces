using Other;
using System.Collections.Generic;

namespace Model
{
    public class DefaultGamemode : Gamemode
    {
        private readonly ReactiveValue<float> _timer = new();

        public IReactiveValue<float> Timer => _timer;

        public override void OnFrameUpdated(float deltaTime)
        {
            if (IsPaused == false && Level.IsActive())
            {
                _timer.Value += deltaTime;

                if (GetSnakes().Count <= default(int))
                {
                    End();
                }
            }
        }

        private List<SnakeHead> GetSnakes()
        {
            return Level.CurrentLevel.Grid.GetObjectsOfType<SnakeHead>();
        }
    }
}