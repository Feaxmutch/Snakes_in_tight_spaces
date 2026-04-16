using ViewModel;
using Model;

public class ComplitionWindowRoot : DefaultWindowRoot
{
    private Gamemode _gamemode;

    public void SetGamemode(Gamemode gamemode)
    {
        _gamemode = gamemode;
    }

    protected override void CreateAll()
    {
        if(ViewModel == null) ViewModel = CreateViewModel<ComplitionWindowVM>();
    }

    protected override void InitViewModel()
    {
        base.InitViewModel();
        (ViewModel as ComplitionWindowVM).Initialize(_gamemode);
    }
}