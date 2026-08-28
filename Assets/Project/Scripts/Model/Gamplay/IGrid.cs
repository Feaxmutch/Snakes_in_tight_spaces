using System;
using System.Collections.Generic;
using Other;


namespace Model
{
    public interface IGrid
    {
        event Action ObjectRemoved;

        bool CanBePlaced(GridObject gridObject, Vector2Int position);
        bool ContainsObject(GridObject gridObject);
        void PlaceObject(GridObject gridObject, Vector2Int position);
        void RemoveObject(GridObject gridObject);
        Vector2Int GetObjectPosition(GridObject gridObject);
        GridObject[] GetObjectsByPosition(Vector2Int position);
        List<T> GetObjectsOfType<T>() where T : GridObject;
    }
}