using Model;
using ViewModel;
using Other;


public class SnakeBodyRoot : EntityRoot<SnakeBody, EntityVM, SnakeBodyV>
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