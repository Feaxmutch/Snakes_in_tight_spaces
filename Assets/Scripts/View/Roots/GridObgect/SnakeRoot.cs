using Model;
using System;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;
using Vector2Int = Other.Vector2Int;

public class SnakeRoot : MonoBehaviour 
{
    [SerializeField] private UpdateBroadcaster _updateBroadcaster;
    [SerializeField] private InputBroadcaster _inputBroadcaster;
    [SerializeField] private SnakeHeadV _headView;
    [SerializeField] private List<SnakeBodyV> _bodyViewes;
    [SerializeField] private int _colorIndex;

    public Dictionary<Vector2Int, GridObject> Compose(float speed)
    {
        SnakeHeadFactory headFactory = new();

        int x = 0;
        int y = 0;
        Dictionary<Vector2Int, GridObject> gridObjects = new();
        List<SnakeBody> bodyes = new();
        Color headColor = GameplayColors.Instance.ColorPack.Colors[_colorIndex];

        foreach (var bodyView in _bodyViewes)
        {
            x = (int)bodyView.transform.position.x;
            y = (int)bodyView.transform.position.z;
            SnakeBody body = new();
            body.Initialize(Other.Color.ConvertFromUnity(headColor));
            gridObjects[new Vector2Int(x, y)] = body;
            bodyes.Add(body);
            Destroy(bodyView.gameObject);
        }

        x = (int)_headView.transform.position.x;
        y = (int)_headView.transform.position.z;
        Other.Color modelColor = Other.Color.ConvertFromUnity(headColor);
        SnakeHead head = headFactory.Create(modelColor, speed, bodyes);
        gridObjects[new Vector2Int(x, y)] = head;
        SnakeVM headViewModel = new();
        headViewModel.Initialize(modelColor, head, _inputBroadcaster, _updateBroadcaster);
        _headView.Initialize(headViewModel);
        return gridObjects;
    }
}