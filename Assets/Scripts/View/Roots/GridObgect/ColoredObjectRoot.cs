using Model;
using ViewModel;
using UnityEngine;

public class ColoredObjectRoot<M, VM, V> : GridObjectRoot<M, VM, V> where M : ColoredObject, new() where VM : ColoredObjectVM, new() where V : ColoredObjectV 
{
    [SerializeField] private int _colorIndex;

    protected int ColorIndex => _colorIndex;

    public override void Compose(M model = null, VM viewModel = null)
    {
        CreateModel();
        CreateViewModel(model);
        InitializeView(viewModel);
    }

    public override void Compose()
    {
        Compose(null, null);
    }

    protected override void CreateModel()
    {
        Other.Color modelColor = Other.Color.ConvertFromUnity(GameplayColors.Instance.ColorPack.Colors[_colorIndex]);
        ColoredObjectFactory factory = new();
        Model = factory.Create<M>(modelColor);
    }

    protected override void CreateViewModel(M model = null)
    {
        ViewModel = new();

        if (model != null)
        {
            Model = model;
        }

        ViewModel.Initialize(Other.Color.ConvertFromUnity(GameplayColors.Instance.ColorPack.Colors[_colorIndex]), Model);
    }

    protected override void InitializeView(VM viewModel = null)
    {
        if (viewModel != null)
        {
            ViewModel = viewModel;
        }

        View.Initialize(ViewModel);
    }
}