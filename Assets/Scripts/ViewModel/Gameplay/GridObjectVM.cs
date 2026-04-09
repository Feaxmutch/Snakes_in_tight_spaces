using Model;
using UnityEngine;
using Other;
using Vector2Int = Other.Vector2Int;
using System;

namespace ViewModel
{
    public class GridObjectVM
    {
        private readonly ReactiveValue<Vector2Int> _modelPosition = new();
        private readonly ReactiveValue<Vector2> _interpolatedPosition = new();

        private GridObject _gridObject;
        private IUnityUpdate _unityUpdate;
        
        public event Action Destroyed;

        public bool IsUseInterpolation { get; private set; }

        public IReactiveValue<Vector2Int> ModelPosition => _modelPosition;

        public IReactiveValue<Vector2> InterpolatedPosition => _interpolatedPosition;

        public float InterpolationSpeed { get; private set; }

        public void Initialize(GridObject gridObject, bool isUseInterpolation = false, IUnityUpdate unityUpdate = null)
        {
            _gridObject = gridObject;
            _gridObject.PositionChanged += OnPositionChanged;
            _gridObject.Destroyed += OnDestroy;
            _gridObject.Started += OnModelStart;
            IsUseInterpolation = isUseInterpolation;

            if (IsUseInterpolation)
            {
                _unityUpdate = unityUpdate;
                _unityUpdate.Updated += OnUpdate;
            }

            if (_gridObject.IsInLevel(false))
            {
                _modelPosition.Value = _gridObject.GetPosition();
                _interpolatedPosition.Value = new Vector2(ModelPosition.Value.X, ModelPosition.Value.Y);
            }
        }

        public void SetSpeed(float speed)
        {
            InterpolationSpeed = speed;
        }

        protected virtual void OnModelStart()
        {
            _modelPosition.Value = new Vector2Int(ModelPosition.Value.X, ModelPosition.Value.Y);
            _interpolatedPosition.Value = new Vector2(ModelPosition.Value.X, ModelPosition.Value.Y);
        }

        private void OnPositionChanged(Vector2Int vector)
        {
            _modelPosition.Value = vector;
        }

        protected virtual void OnUpdate(float deltaTime)
        {
            float x = Mathf.MoveTowards(InterpolatedPosition.Value.x, ModelPosition.Value.X, deltaTime * InterpolationSpeed);
            float y = Mathf.MoveTowards(InterpolatedPosition.Value.y, ModelPosition.Value.Y, deltaTime * InterpolationSpeed);
            _interpolatedPosition.Value = new Vector2(x, y);
        }

        private void OnDestroy()
        {
            Destroyed?.Invoke();

            if (_unityUpdate != null)
            {
                _unityUpdate.Updated -= OnUpdate;
            }
        }
    }
}