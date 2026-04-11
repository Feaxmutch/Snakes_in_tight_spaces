using ViewModel;

public class DefaultWindowRoot : AnimatedWindowRoot<DefaultWindowVM, DefaultWindowV>
{
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