using UnityEngine;
using Model;
using TMPro;
public class GameplayRoot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelTitle;
    [SerializeField] private GamemodeWindowRoot _gamemodeWindow;
    [SerializeField] private UpdateBroadcaster _updateBroadcaster;
    [SerializeField] private ComplitionWindowRoot _complitionWindow;
    [SerializeField] private MenuRoot _menuRoot;

    private void Start()
    {
        Compose();
    }

    private void Compose()
    {
        DefaultGamemode gamemode = new();
        LevelData levelData = LevelSelector.Instance.CurrentLevel;
        LevelRoot levelRoot = Instantiate(levelData.LevelPrefab);
        Level level = levelRoot.Compose(levelData, gamemode);
        _levelTitle.text = levelData.Name;
        _menuRoot.SetAdditionalWindows(levelRoot.Windows);
        ComposeInterface(gamemode);
        Level.Start(level);
    }

    private void ComposeInterface(DefaultGamemode gamemode)
    {
        _gamemodeWindow.SetGamemode(gamemode);
        _complitionWindow.SetGamemode(gamemode);
        _gamemodeWindow.Compose();
        _complitionWindow.Compose();
        _menuRoot.Compose();
    }
}