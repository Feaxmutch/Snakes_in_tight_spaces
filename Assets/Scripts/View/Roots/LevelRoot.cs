using UnityEngine;
using Model;
using ViewModel;
using System.Collections.Generic;
using Vector2Int = Other.Vector2Int;
using System.Linq; 
using Other;

public class LevelRoot : MonoBehaviour
{
    [SerializeField] private LevelBackgroundV _cornerPrefab;
    [SerializeField] private byte _styleId;
    [SerializeField] private FlorV _flor;
    [SerializeField] private Camera _camera;
    [SerializeField] private BaseGridObjectRoot[] _gridObjectRoots;
    [SerializeField] private SnakeRoot[] _snakes;

    [field : SerializeField] public DefaultWindowRoot[] Windows { get; private set; }

    public Level Compose(LevelData levelData, Gamemode gamemode)
    {
        Array2d<GridObject> levelGrid = new(levelData.Size.x, levelData.Size.y);

        ComposeViews(_gridObjectRoots, levelGrid);

        foreach (var snakeRoot in _snakes)
        {
            Dictionary<Vector2Int, GridObject> composedSnake = snakeRoot.Compose(levelData.SnakesSpeed, _styleId);
            List<Vector2Int> positions = composedSnake.Keys.ToList();

            foreach (var position in positions)
            {
                levelGrid[position.X, position.Y] = composedSnake[position];
            }
        }

        Camera mainCamera = Camera.main;

        if (mainCamera != _camera)
        {
            mainCamera.enabled = false;
            _camera.enabled = true;
        }

        _flor.ScaleMaterial(levelData.Size);
        Level level = new(levelGrid, gamemode);
        
        for (int y = -1; y <= 1; y++)
        {
            for (int x = -1; x <= 1; x++)
            {
                if (x == 0 && y == 0)
                {
                    continue;
                }

                LevelBackgroundV currentBackground = Instantiate(_cornerPrefab);
                currentBackground.SetMaterial(GameplayMaterials.Instance.Styles[_styleId].Wall);
                currentBackground.SetSize(new Vector2Int(levelGrid.LengthX, levelGrid.LengthY));
                currentBackground.SetPosition(new Vector2Int(x, y), new Vector2Int(levelGrid.LengthX, levelGrid.LengthY));
            }
        }

        return level;
    }

    private void ComposeViews(BaseGridObjectRoot[] roots, Array2d<GridObject> levelObjects)
    {
        Vector2Int[] modelPositions = new Vector2Int[roots.Length];

        for (int i = 0; i < modelPositions.Count(); i++)
        {
            int x = (int)roots[i].BaseView.transform.position.x;
            int y = (int)roots[i].BaseView.transform.position.z;
            modelPositions[i] = new(x, y);
        }

        for (int i = 0; i < modelPositions.Count(); i++)
        {
            if (roots[i].BaseView.IsInitialized == false)
            {
                roots[i].Compose(_styleId);
            }

            levelObjects[modelPositions[i].X, modelPositions[i].Y] = roots[i].BaseModel;
        }
    }
}