using Model;
using ViewModel;
using Other;

public class ExitRoot : ColoredObjectRoot<Exit, ExitVM, ExitV>
{
    protected override void CreateAll()
    {
        if(Model == null) Model = new Exit();
        if(ViewModel == null) ViewModel = new ExitVM();
    }

    protected override void InitModel()
    {
        base.InitModel();
        Vector2Int exitForward = new Vector2Int((int)View.transform.forward.x, (int)View.transform.forward.z);
        Model.Initialize(exitForward);
    }

    protected override void InitViewModel()
    {
        base.InitViewModel();
        ViewModel.Initialize(Model);
    }

    protected override void InitView()
    {
        base.InitView();
        View.Initialize(ViewModel);
    }
}