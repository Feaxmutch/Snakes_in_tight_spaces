using UnityEngine;
using ViewModel;

public class LevelSelector : BootstrapComponent<LevelSelector>, ILevelSelector
{
    [SerializeField] private LevelList _levelList;

    private int _selectedIndex = 0;
    
    public LevelData CurrentLevel => _levelList.Levels[_selectedIndex];

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }

    public void SelectLevel(int index)
    {
        _selectedIndex = index;
    }

    public void NextLevel()
    {
        _selectedIndex++;
    }
}