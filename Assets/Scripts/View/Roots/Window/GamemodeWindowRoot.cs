using Model;
using ViewModel;

public class GamemodeWindowRoot : AnimatedWindowRoot<GamemodeWindowVM, GamemodeWindowV>
{
    private DefaultGamemode _gamemode;
    
    public void SetGamemode(DefaultGamemode gamemode)
    {
        _gamemode = gamemode;
    }

    protected override void InitViewModel()
    {
        base.InitViewModel();
        ViewModel.Initialize(_gamemode);
    }

    protected override void InitView()
    {
        base.InitView();
        View.Initialize(ViewModel);
    }
}