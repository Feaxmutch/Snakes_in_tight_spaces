using Model;
using ViewModel;
using System;
using UnityEngine;

public class PauseActionV : ButtonActionV
{
    public override void Perform()
    {
        if (Level.IsActive() == false)
        {
            throw new InvalidOperationException("Gamemode can't be existing. Level dosent active");
        }

        Level.CurrentLevel.Gamemode.Pause();
    }
}