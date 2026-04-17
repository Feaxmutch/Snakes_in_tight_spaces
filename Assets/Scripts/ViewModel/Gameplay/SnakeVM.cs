using Model;
using Other;
using System;
using UnityEngine;
using Vector2Int = Other.Vector2Int;
using Color = Other.Color;

namespace ViewModel
{
    public class SnakeVM : ColoredObjectVM
    {
        private readonly ReactiveValue<Quaternion> _rotation =new(Quaternion.LookRotation(Vector3.right));

        private float _eleapsedTime = 0f;
        private SnakeHead _head;
        private bool _isPatching = false;
        private IUserInput _userInput;

        public event Action<SnakeBody> Growed;

        public IReactiveValue<Quaternion> Rotation => _rotation;

        public void Initialize(SnakeHead head, IUserInput userInput)
        {
            _head = head;
            _head.Growed += OnGrow;
            _userInput = userInput;
            SetSpeed(_head.Speed);
        }

        protected override void OnUpdate(float deltaTime)
        {
            base.OnUpdate(deltaTime);
            HandleMouseInput();

            if (_isPatching)
            {
                _head.AddPatchPoint(RoundMousePosition());
            }

            _eleapsedTime += deltaTime;

            if (_eleapsedTime > GetStepDelay())
            {
                _eleapsedTime -= GetStepDelay();
                _head.Move();
                RotateToModel();
            }
        }

        private void HandleMouseInput()
        {
            if (_userInput.IsMouseHold)
            {
                if (_isPatching == false)
                {
                    if (RoundMousePosition() == _head.GetPosition())
                    {
                        _isPatching = true;
                        return;
                    }
                }
            }
            else
            {
                _isPatching = false;
                return;
            }
        }

        private Vector2Int RoundMousePosition()
        {
            int x = Mathf.RoundToInt(_userInput.MousePosition.x);
            int y = Mathf.RoundToInt(_userInput.MousePosition.y);
            return new Vector2Int(x, y);
        }

        private float GetStepDelay()
        {
            return 1 / _head.Speed;
        }

        private void OnGrow(SnakeBody body)
        {
            Growed?.Invoke(body);
        }

        private void RotateToModel()
        {
            Vector2 modelPosition = ModelPosition.Value.ConvertToVector2();
            Vector2 lookVector = modelPosition - InterpolatedPosition.Value;

            if (lookVector != Vector2.zero)
            {
                _rotation.Value = Quaternion.LookRotation(new Vector3(lookVector.x, 0, lookVector.y));
            }
            
        }
    }
}