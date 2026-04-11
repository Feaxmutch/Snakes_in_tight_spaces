using ViewModel;
using Model;

public class ComplitionWindowRoot : DefaultWindowRoot
{
    private Gamemode _gamemode;

    public void Compose(Gamemode gamemode)
    {
        _gamemode = gamemode;
        if(ViewModel == null) ViewModel = CreateViewModel<ComplitionWindowVM>();
        InitViewModel();
        InitView();
    }

    protected override void InitViewModel()
    {
        base.InitViewModel();
        (ViewModel as ComplitionWindowVM).Initialize(_gamemode);
    }
}