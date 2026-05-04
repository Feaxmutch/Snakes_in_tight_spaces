using ViewModel;
using Model;

public class ComplitionWindowRoot : AnimatedWindowRoot<ComplitionWindowVM, DefaultWindowV>
{
    private Gamemode _gamemode;

    public void SetGamemode(Gamemode gamemode)
    {
        _gamemode = gamemode;
    }

    protected override void InitViewModel()
    {
        base.InitViewModel();
        ViewModel.Initialize(_gamemode);
    }
}