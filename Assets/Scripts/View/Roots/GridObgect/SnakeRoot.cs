using Model;
using System.Collections.Generic;
using UnityEngine;
using Vector2Int = Other.Vector2Int;

public class SnakeRoot : MonoBehaviour 
{
    [SerializeField] private List<SnakeBodyRoot> _bodyRoots;
    [SerializeField] private SnakeHeadRoot _headRoot;

    public Dictionary<Vector2Int, GridObject> Compose(float speed)
    {
        int x;
        int y;
        Dictionary<Vector2Int, GridObject> gridObjects = new();
        List<SnakeBody> bodyes = new();

        foreach (var bodyRoot in _bodyRoots)
        {
            x = (int)bodyRoot.transform.position.x;
            y = (int)bodyRoot.transform.position.z;
            bodyRoot.Compose();
            gridObjects[new Vector2Int(x, y)] = bodyRoot.Model;
            bodyes.Add(bodyRoot.Model);
            Destroy(bodyRoot.gameObject);
        }

        x = (int)_headRoot.transform.position.x;
        y = (int)_headRoot.transform.position.z;
        _headRoot.SetBodies(bodyes);
        _headRoot.SetSpeed(speed);
        _headRoot.Compose();
        gridObjects[new Vector2Int(x, y)] = _headRoot.Model;
        return gridObjects;
    }
}