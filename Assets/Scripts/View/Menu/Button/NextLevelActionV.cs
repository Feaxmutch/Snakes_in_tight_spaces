using Model;

public class NextLevelActionV : ButtonActionV
{
    public override void Perform()
    {
        if (Level.IsActive())
        {
            Level.Stop();
        }

        LevelSelector.Instance.NextLevel();
    }
}