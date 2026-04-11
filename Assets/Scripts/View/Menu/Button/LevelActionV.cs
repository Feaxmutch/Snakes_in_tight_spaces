using Model;
using UnityEngine;

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