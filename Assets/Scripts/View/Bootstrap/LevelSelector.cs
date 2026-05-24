using Model;
using UnityEngine;
using ViewModel;
using System;
using Other;
using System.Linq;

public class LevelSelector : BootstrapComponent<LevelSelector>, ILevelSelector
{
    [SerializeField] private LevelList _levelList;

    private int _selectedIndex = 0;

    public event Action LevelChanged;

    public LevelData CurrentLevel => _levelList.Levels[_selectedIndex];

    public bool IsLastLevel => _selectedIndex == Array.IndexOf(_levelList.Levels, _levelList.Levels.Last());

    protected override void Awake()
    {
        base.Awake();
        Instance = this;

        if (Level.IsActive())
        {
            Level.Stop();
        }
    }

    public void SelectLevel(int index)
    {
        _selectedIndex = index;
        LevelChanged?.Invoke();
    }

    public void NextLevel()
    {
        if (IsLastLevel)
        {
            return; 
        }

        _selectedIndex++;
        LevelChanged?.Invoke();
    }
}