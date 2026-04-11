using Model;
using ViewModel;

public class GamemodeWindowRoot : DefaultWindowRoot
{
    private DefaultGamemode _gamemode;
    private GamemodeWindowVM _viewModel;
    private GamemodeWindowV _view;
    
    public void Compose(DefaultGamemode gamemode)
    {
        _gamemode = gamemode;
        ViewModel = new GamemodeWindowVM();
        _viewModel = ViewModel as GamemodeWindowVM;
        _view = View as GamemodeWindowV;
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

    protected override void InitView()
    {
        base.InitView();
        
        if (_view != null)
        {
            _view.Initialize(_viewModel);
        }
    }
}