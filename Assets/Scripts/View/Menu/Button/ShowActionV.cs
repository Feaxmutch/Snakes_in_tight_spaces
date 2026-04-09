using ViewModel;
using UnityEngine;

public class ShowActionV : WindowActionV
{
    public override void Perform()
    {
        TargetWindow.Show();
    }
}