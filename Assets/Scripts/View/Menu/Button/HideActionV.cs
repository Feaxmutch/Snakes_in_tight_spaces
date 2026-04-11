public class HideActionV : WindowActionV
{
    public override void Perform()
    {
        TargetWindow.Hide();
    }
}