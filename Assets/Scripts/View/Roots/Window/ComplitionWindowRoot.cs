using ViewModel;
using Model;

public class ComplitionWindowRoot : DefaultWindowRoot
{
    private Gamemode _gamemode;
    private ComplitionWindowVM _viewModel;

    public void Compose(Gamemode gamemode)
    {
        _gamemode = gamemode;
        ViewModel = new ComplitionWindowVM();
        _viewModel = ViewModel as ComplitionWindowVM;
        InitViewModel();
        InitView();
    }

    protected override void InitViewModel()
    {
        base.InitViewModel();

        if (_viewModel != null)
        {
            _viewModel.Initialize(_gamemode);
        }
    }
}