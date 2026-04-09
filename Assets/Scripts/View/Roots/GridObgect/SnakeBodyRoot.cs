using Model;
using ViewModel;
using Other;

public class SnakeBodyRoot : ColoredObjectRoot<SnakeBody, ColoredObjectVM, SnakeBodyV>
{
    public void Compose(SnakeBody body, float speed, Color color, IUnityUpdate unityUpdate)
    {
        CreateViewModel(body, color, unityUpdate);
        InitializeView();
        ViewModel.SetSpeed(speed);
    }

    protected void CreateViewModel(SnakeBody model, Color color, IUnityUpdate unityUpdate)
    {
        ViewModel = new();
        ViewModel.Initialize(color, model, true, unityUpdate);
    }

}