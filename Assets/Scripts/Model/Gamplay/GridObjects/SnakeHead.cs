using Vector2Int = Other.Vector2Int;
using System.Collections.Generic;
using System.Linq;
using System;
using Other;

namespace Model
{
    public class SnakeHead : ColoredObject
    {
        private List<SnakeBody> _notAddedBodyes = new();
        private List<Vector2Int> _bodyPositions = new();
        private List<SnakeBody> _bodyes = new();
        private Queue<Vector2Int> _patchPoints = new();
        private bool _isInExit;

        public event Action<SnakeBody> Growed;

        public SnakeHead() : base() { }

        public float Speed { get; private set; }

        public void Initialize(float speed, List<SnakeBody> snakeBodies)
        {
            _notAddedBodyes = snakeBodies;
            Speed = speed;
            _isInExit = false;
        }

        public override void OnStart()
        {
            base.OnStart();
            _bodyPositions.Add(GetPosition());

            foreach (var body in _notAddedBodyes)
            {
                Grow(body);
            }
        }

        public void Move()
        {
            Level level = Level.CurrentLevel;

            if (CanMove() == false)
            {
                return;
            }

            Vector2Int nextPosition = _patchPoints.Dequeue();
            Vector2Int lastBodyPosition = level.Grid.GetObjectPosition(_bodyes.Last());
            bool isEatedApple = false;
            bool isGoldApple = false;

            if (ContainsOnPosition(nextPosition, out Apple apple))
            {
                if (ContainsOnPosition(nextPosition, out GoldApple goldApple))
                {
                    isGoldApple = true;
                }

                apple.Destroy();
                isEatedApple = true;
            }

            if (ContainsOnPosition(nextPosition, out Exit exit))
            {
                if (exit.Color == Color && exit.IsOpened.Value == true)
                {
                    _patchPoints.Clear();
                    Vector2Int currentPosition = GetPosition();

                    for (int i = 2; i < _bodyPositions.Count + 3; i++)
                    {
                        _patchPoints.Enqueue(currentPosition + exit.ForwardDirection * i);
                    }

                    _isInExit = true;
                }  
            }
        
            SetPosition(nextPosition);
            MoveBodyes(nextPosition);

            if (isEatedApple)
            {
                if (isGoldApple)
                {
                    CutHalf();
                    return;
                }

                SnakeBody snakeBody = new();
                snakeBody.Initialize(Color);
                level.Grid.PlaceObject(snakeBody, lastBodyPosition);
                Grow(snakeBody);
            }

            if (_patchPoints.Count <= default(int))
            {
                if (_isInExit)
                {
                    DestroyAll();
                }
            }
        }

        public void AddPatchPoint(Vector2Int position)
        {
            if (CanAddPoint(position) == false)
            {
                return;
            }

            if (ContainsOnPosition(position, out GoldApple goldApple))
            {
                if (goldApple.IsLocked.Value )
                {
                    return;
                }

                _patchPoints.Enqueue(position);
                return;
            }

            if (ContainsOnPosition(position, out Apple apple))
            {
                if (apple.Color != Color || apple.IsLocked.Value)
                {   
                    return;
                }
            }

            _patchPoints.Enqueue(position);
        }

        private bool CanAddPoint(Vector2Int position)
        {
            if (_patchPoints.Contains(position))
            {
                return false;
            }

            if (_bodyPositions.Contains(position))
            {
                return false;
            }

            if (Level.CurrentLevel.Gamemode.IsPaused)
            {
                return false;
            }

            if (_patchPoints.Count > 0)
            {
                if (Vector2Int.Distance(_patchPoints.Last(), position) > 1)
                {
                    return false;
                }
            }
            else
            {
                if (Vector2Int.Distance(_bodyPositions.First(), position) > 1)
                {
                    return false;
                }
            }

            if (CanBePlaced(position) == false)
            {
                return false;
            }

            return true;
        }

        private bool CanMove()
        {
            if (_bodyPositions.Count == 0)
            {
                return false;
            }

            if (_patchPoints.Count == 0)
            {
                return false;
            }

            return true;
        }

        private bool ContainsOnPosition<T>(Vector2Int position, out T result) where T : GridObject
        {
            GridObject[] objectsOnPosition = Level.CurrentLevel.Grid.GetObjectsByPosition(position);

            foreach (var gridObject in objectsOnPosition)
            {
                if (gridObject is T)
                {
                    result = gridObject as T;
                    return true;
                }
            }

            result = null;
            return false;
        }

        private bool CanGrow(SnakeBody body)
        {
            Level currentLevel = Level.CurrentLevel;

            if (_bodyes.Contains(body))
            {
                return false;
            }

            if (body.IsInLevel() == false)
            {
                return false;
            }

            if (Vector2Int.Distance(currentLevel.Grid.GetObjectPosition(body), _bodyPositions.Last()) > 1)
            {
                return false;
            }

            return true;
        }

        private void Grow(SnakeBody body)
        {
            Level currentLevel = Level.CurrentLevel;

            if (CanGrow(body) == false)
            {
                return;
            }

            _bodyes.Add(body);
            _bodyPositions.Add(currentLevel.Grid.GetObjectPosition(_bodyes.Last()));
            Growed?.Invoke(body);
        }

        private void CutHalf()
        {
            int halfOfCount = (int)Math.Round((double)(_bodyes.Count / 2), 1);
            var bodyesForCut = _bodyes.GetRange(halfOfCount, _bodyes.Count - halfOfCount);

            foreach (var body in bodyesForCut)
            {
                _bodyes.Remove(body);
                body.Destroy();
            }
        }

        private void MoveBodyes(Vector2Int nextHeadPosition)
        {
            int lastBodyPosition = _bodyPositions.IndexOf(_bodyPositions.Last());

            for (int i = lastBodyPosition; i >= 0; i--)
            {
                if (i == 0)
                {
                    _bodyPositions[i] = nextHeadPosition;
                }
                else
                {
                    _bodyPositions[i] = _bodyPositions[i - 1];
                }
            }

            for (int i = 0; i < _bodyes.Count; i++)
            {
                _bodyes[i].SetPosition(_bodyPositions[i + 1]);
            }
        }

        private void DestroyAll()
        {
            foreach (var body in _bodyes)
            {
                body.Destroy();
            }

            Destroy();
        }
    }
}