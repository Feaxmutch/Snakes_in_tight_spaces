using Model;
using System;

public class UnpauseActionV : ButtonActionV
{
    public override void Perform()
    {
        if (Level.IsActive() == false)
        {
            throw new InvalidOperationException("Gamemode can't be existing. Level dosent active");
        }

        Level.CurrentLevel.Gamemode.Unpause();
    }
}