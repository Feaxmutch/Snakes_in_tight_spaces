using Model;
using ViewModel;

public class GamemodeWindowRoot : DefaultWindowRoot
{
    private DefaultGamemode _gamemode;
    
    public void SetGamemode(DefaultGamemode gamemode)
    {
        _gamemode = gamemode;
    }

    protected override void CreateAll()
    {
        if(ViewModel == null) ViewModel = CreateViewModel<GamemodeWindowVM>();
    }

    protected override void InitViewModel()
    {
        base.InitViewModel();
        (ViewModel as GamemodeWindowVM).Initialize(_gamemode);
    }

    protected override void InitView()
    {
        base.InitView();
        (View as GamemodeWindowV).Initialize(ViewModel as GamemodeWindowVM);
    }
}