using UnityEngine;
using Model;
using ViewModel;
using System.Collections.Generic;
using Vector2Int = Other.Vector2Int;
using System.Linq; 
using Other;

public class LevelRoot : MonoBehaviour
{
    [SerializeField] private FlorV _flor;
    [SerializeField] private Camera _camera;
    [SerializeField] private UpdateBroadcaster _updateBroadcaster;
    [SerializeField] private SnakeRoot[] _snakes;
    [SerializeField] private AppleRoot[] _appleRoots;
    [SerializeField] private GoldAppleRoot[] _goldAppleRoots;
    [SerializeField] private WallRoot[] _wallRoots;
    [SerializeField] private ExitRoot[] _exitRoots;

    [field : SerializeField] public DefaultWindowRoot[] Windows { get; private set; }

    public Level Compose(LevelData levelData, Gamemode gamemode)
    {
        Array2d<GridObject> levelMatrix = new(levelData.Size.x, levelData.Size.y);
        ColoredObjectFactory coloredFactory = new();
        GridObjectFactory factory = new();

        ComposeViews(_appleRoots, levelMatrix);
        ComposeViews(_goldAppleRoots, levelMatrix);
        ComposeViews(_wallRoots, levelMatrix);
        ComposeViews(_exitRoots, levelMatrix);

        foreach (var snakeRoot in _snakes)
        {
            Dictionary<Vector2Int, GridObject> composedSnake = snakeRoot.Compose(levelData.SnakesSpeed);
            List<Vector2Int> positions = composedSnake.Keys.ToList();

            foreach (var position in positions)
            {
                levelMatrix[position.X, position.Y] = composedSnake[position];
            }
        }

        Camera mainCamera = Camera.main;

        if (mainCamera != _camera)
        {
            mainCamera.enabled = false;
            _camera.enabled = true;
        }

        _flor.Scale(levelData.Size);
        Level level = new(levelMatrix, gamemode);
        LevelVM levelVM = new(level, _updateBroadcaster);
        return level;
    }

    private void ComposeViews<M, VM, V>(GridObjectRoot<M, VM, V>[] roots, Array2d<GridObject> levelObjects) 
        where M : GridObject, new() 
        where VM : GridObjectVM, new() 
        where V : DefaultGridObjectV
    {
        Vector2Int[] modelPositions = new Vector2Int[roots.Length];

        for (int i = 0; i < modelPositions.Count(); i++)
        {
            int x = (int)roots[i].View.transform.position.x;
            int y = (int)roots[i].View.transform.position.z;
            modelPositions[i] = new(x, y);
        }

        for (int i = 0; i < modelPositions.Count(); i++)
        {
            if (roots[i].View.IsInitialized == false)
            {
                roots[i].Compose();
            }

            levelObjects[modelPositions[i].X, modelPositions[i].Y] = roots[i].Model;
        }
    }
}