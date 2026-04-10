using ViewModel;
using Other;
using UnityEngine;
using Animation = Other.Animation;

public class DefaultWindowRoot : AnimatedWindowRoot<DefaultWindowVM, DefaultWindowV>
{
    public override void Compose()
    {
        if (ViewModel == null)
        {
            ViewModel = new();
        }
        
        InitViewModel();
        InitView();
    }

    protected override void InitViewModel()
    {
        base.InitViewModel();
        ViewModel.Init();
    }

    protected override void InitView()
    {
        base.InitView();
        View.Init(ViewModel);
    }
}