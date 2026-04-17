using Model;
using ViewModel;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHeadRoot : ColoredObjectRoot<SnakeHead, SnakeVM, SnakeHeadV>
{
    [SerializeField] private InputBroadcaster _inputBroadcaster;

    private List<SnakeBody> _bodies = new();


    public void SetBodies(List<SnakeBody> bodies)
    {
        _bodies = bodies;
    }

    protected override void InitModel()
    {
        base.InitModel();
        Model.Initialize(InterpolationSpeed, _bodies);
    }

    protected override void InitViewModel()
    {
        SetInterpolation(true);
        base.InitViewModel();
        ViewModel.Initialize(Model, _inputBroadcaster);
    }

    protected override void InitView()
    {
        base.InitView();
        View.Initialize(ViewModel);
    }
}