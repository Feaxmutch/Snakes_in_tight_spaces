using Model;
using ViewModel;
using Other;
using UnityEngine;
using Vector2Int = Other.Vector2Int;
using Animation = Other.Animation;

public class ExitRoot : ColoredObjectRoot<Exit, ExitVM, ExitV>
{
    [SerializeField] private AnimationData _openData;
    [SerializeField] private AnimationData _closeData;

    private Animation _openAnimation = new();
    private Animation _closeAnimation = new();

    
    protected override void CreateAll()
    {
        if(Model == null) Model = new Exit();
        if(ViewModel == null) ViewModel = new ExitVM();
    }

    protected override void InitModel()
    {
        base.InitModel();
        Vector2Int exitForward = new Vector2Int((int)View.transform.forward.x, (int)View.transform.forward.z);
        Model.Initialize(exitForward);
    }

    protected override void InitViewModel()
    {
        base.InitViewModel();
        InitAnimations();
        ViewModel.Initialize(Model, _openAnimation, _closeAnimation, UpdateBroadcaster);
    }

    protected override void InitView()
    {
        base.InitView();
        View.Initialize(ViewModel);
    }

    private void InitAnimations()
    {
        _openAnimation.SetLimits(_openData.StartValue, _openData.EndValue);
        _closeAnimation.SetLimits(_closeData.StartValue, _closeData.EndValue);
        _openAnimation.SetDuration(_openData.Duration);
        _closeAnimation.SetDuration(_closeData.Duration);
        _openAnimation.SetCurve(new Curve(_openData.Curve));
        _closeAnimation.SetCurve(new Curve(_closeData.Curve));
    }
}