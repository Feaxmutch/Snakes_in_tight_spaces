using Model;
using ViewModel;
using Other;


public class SnakeBodyRoot : ColoredObjectRoot<SnakeBody, ColoredObjectVM, SnakeBodyV>
{
    public void SetBody(SnakeBody body)
    {
        Model = body;
    }

    protected override void InitViewModel()
    {
        SetInterpolation(true);
        base.InitViewModel();
    }
}