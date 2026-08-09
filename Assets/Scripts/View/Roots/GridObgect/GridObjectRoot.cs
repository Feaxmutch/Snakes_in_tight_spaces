using UnityEngine;
using Model;
using ViewModel;

public abstract class GridObjectRoot<M, VM, V> : BaseGridObjectRoot where M : GridObject, new() where VM : GridObjectVM, new() where V : DefaultGridObjectV
{
    private bool _isUseInterpolation = false;
    
    [field : SerializeField] public byte StyleId { get; private set; }

    [field : SerializeField] public UpdateBroadcaster UpdateBroadcaster {get; private set;}

    [field : SerializeField] public V View { get; private set; }

    public override GridObject BaseModel => Model;

    public override GridObjectV BaseView => View;

    protected float InterpolationSpeed { get; private set; } = 1f;

    public M Model { get; protected set; }

    protected VM ViewModel { get; set; }

    

    public override void Compose(byte styleId)
    {
        StyleId = styleId;
        CreateAll();
        InitAll();
    }

    public void SetSpeed(float value)
    {
        InterpolationSpeed = value;
    }

    protected void SetInterpolation(bool value)
    {
        _isUseInterpolation = value;
    }

    protected virtual void CreateAll()
    {
        if(Model == null)  Model = new M();
        if(ViewModel == null) ViewModel = new VM();
    }

    protected T CreateModel<T>() where T : GridObject, new()
    {
        return new T();
    }

    protected virtual void InitModel()
    {
        
    }

    protected virtual void InitViewModel()
    {
        ViewModel.SetSpeed(InterpolationSpeed);
        ViewModel.Initialize(Model, _isUseInterpolation, UpdateBroadcaster);
    }

    protected virtual void InitView()
    {
        View.Initialize(ViewModel, StyleId);
    }

    private void InitAll()
    {
        InitModel();
        InitViewModel();
        InitView();
    }
}