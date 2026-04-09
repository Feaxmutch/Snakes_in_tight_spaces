using Model;
using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ViewModel;

public class LevelActionV : ButtonActionV
{
    [Min(0)][SerializeField] private int _levelIndex;

    public int LevelIndex => _levelIndex;

    public override void Perform()
    {
        if (Level.IsActive())
        {
            Level.Stop();
        }

        LevelSelector.Instance.SelectLevel(_levelIndex);
    }
}