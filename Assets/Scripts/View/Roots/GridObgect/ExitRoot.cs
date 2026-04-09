using Model;
using ViewModel;
using Other;

public class ExitRoot : ColoredObjectRoot<Exit, ExitVM, ExitV>
{
    protected override void CreateModel()
    {
        base.CreateModel();
        Vector2Int exitForward = new Vector2Int((int)View.transform.forward.x, (int)View.transform.forward.z);
        Model.Initialize(exitForward);
    }

    protected override void CreateViewModel(Exit model = null)
    {
        base.CreateViewModel(model);
        ViewModel.Initialize(Color.ConvertFromUnity(GameplayColors.Instance.ColorPack.Colors[ColorIndex]), Model);
    }

    protected override void InitializeView(ExitVM viewModel = null)
    {
        base.InitializeView(viewModel);
        View.Initialize(ViewModel);
    }
}