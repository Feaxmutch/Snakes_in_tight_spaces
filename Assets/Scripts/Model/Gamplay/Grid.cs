using System;
using System.Collections.Generic;
using Other;
using System.Linq;

namespace Model
{
    public class Grid : IGrid
    {
        private TwoSidedList2d<List<GridObject>> _objects;

        public event Action ObjectRemoved;
        
        public void Initialize(Array2d<GridObject> objects)
        {
            _objects = new(objects.LengthX, objects.LengthY);

            for (int x = 0; x < objects.LengthX; x++)
            {
                for (int y = 0; y < objects.LengthY; y++)
                {
                    _objects[x, y] = new();

                    if (objects[x, y] != null)
                    {
                        _objects[x, y].Add(objects[x, y]);
                        InitObject(objects[x, y]);
                    }
                }
            }
        }

        public void StartObjects()
        {
            for (int x = 0; x < _objects.PositiveLengthX; x++)
            {
                for (int y = 0; y < _objects.PositiveLengthY; y++)
                {
                    for (int z = 0; z < _objects[x, y].Count; z++)
                    {
                        _objects[x, y][z]?.OnStart();
                    }
                }
            }
        }

        public bool CanBePlaced(GridObject gridObject, Vector2Int position)
        {
            if (_objects.IsInRange(position) == false)
            {
                _objects.CorrectLength(position);
            }

            if (_objects[position.X, position.Y] == null)
            {
                _objects[position.X, position.Y] = new();
            }

            bool containsSolid = _objects[position.X, position.Y].Any(obj => obj.IsSolid);
            return (gridObject.IsSolid && containsSolid) == false;
        }

        public bool ContainsObject(GridObject gridObject)
        {
            List<GridObject>[] cells = _objects.GetAll().Where(cell => cell.Contains(gridObject)).ToArray();
            return cells.Length > 0;
        }



        public void PlaceObject(GridObject gridObject, Vector2Int position)
        {
            if (ContainsObject(gridObject))
            {
                return;
            }

            if (CanBePlaced(gridObject, position))
            {
                _objects[position.X, position.Y].Add(gridObject);
                gridObject.OnStart();
                gridObject.PositionChanging += MoveObject;
            }
        }

        public void RemoveObject(GridObject gridObject)
        {
            if (ContainsObject(gridObject))
            {
                Vector2Int index = GetObjectPosition(gridObject);
                gridObject.PositionChanging -= MoveObject;
                _objects[index.X, index.Y].Remove(gridObject);
                ObjectRemoved?.Invoke();
            }
        }

        public Vector2Int GetObjectPosition(GridObject gridObject)
        {
            List<GridObject>[] cells = _objects.GetAll().Where(cell => cell.Contains(gridObject)).ToArray();

            if (cells.Length == 0)
            {
                throw new InvalidOperationException("level is not Contains the object");
            }

            return _objects.IndexOf(cells.First());
        }

        public GridObject[] GetObjectsByPosition(Vector2Int position)
        {
            if (_objects.IsInRange(position) == false)
            {
                _objects.CorrectLength(position);
            }

            if (_objects[position.X, position.Y] == null)
            {
                _objects[position.X, position.Y] = new();
            }

            return _objects[position.X, position.Y].ToArray();
        }

        public List<T> GetObjectsOfType<T>() where T : GridObject
        {
            var cellsWithType = _objects.GetAll().Where(cell => cell.Where(obj => obj is T).Count() > 0).ToList();
            List<T> result = new();

            foreach (var cell in cellsWithType)
            {
                result.AddRange(cell.Where(obj => obj is T).Select(obj => obj as T));
            }

            return result;
        }
        
        public void MoveObject(GridObject gridObject, Vector2Int position)
        {
            if (CanBePlaced(gridObject, position))
            {
                Vector2Int previousPosition = GetObjectPosition(gridObject);
                _objects[previousPosition.X, previousPosition.Y].Remove(gridObject);
                _objects[position.X, position.Y].Add(gridObject);
            }
        }

        private void InitObject(GridObject gridObject)
        {
            gridObject.PositionChanging += MoveObject;
        }
    }
}