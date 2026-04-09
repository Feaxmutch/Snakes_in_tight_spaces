using System;
using Other;

namespace Model
{
    public abstract class GridObject
    {
        public event Action Destroyed;
        public event Action<GridObject, Vector2Int> PositionChanging;
        public event Action<Vector2Int> PositionChanged;
        public event Action Started;

        public bool IsSolid { get; private set; }

        public GridObject()
        {
            IsSolid = true;
        }

        public virtual void OnStart()
        {
            if (IsInLevel(true))
            {
                PositionChanged?.Invoke(GetPosition());
                Started?.Invoke();
            }
        }

        public void Destroy()
        {
            Level.CurrentLevel.Grid.RemoveObject(this);
            Destroyed?.Invoke();
        }

        public void SetPosition(Vector2Int position)
        {
            if (IsInLevel(true))
            {
                PositionChanging?.Invoke(this, position);
                PositionChanged?.Invoke(GetPosition());
            }
        }

        public Vector2Int GetPosition()
        {
            IsInLevel(true);
            return Level.CurrentLevel.Grid.GetObjectPosition(this);
        }

        public bool CanBePlaced(Vector2Int position)
        {
            return Level.CurrentLevel.Grid.CanBePlaced(this, position);
        }

        public bool IsInLevel(bool autoDestroy = false)
        {
            bool isInLevel = Level.CurrentLevel?.Grid?.ContainsObject(this) ?? false;

            if (autoDestroy && isInLevel == false)
            {
                Destroy();
            }

            return isInLevel;
        }

        protected void SetSolid(bool value)
        {
            IsSolid = value;
        }
    }
}