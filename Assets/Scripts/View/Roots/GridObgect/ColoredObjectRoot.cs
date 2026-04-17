using Model;
using ViewModel;
using UnityEngine;
using Color = Other.Color;

public class ColoredObjectRoot<M, VM, V> : GridObjectRoot<M, VM, V> where M : ColoredObject, new() where VM : ColoredObjectVM, new() where V : ColoredObjectV 
{
    [SerializeField] private int _colorIndex;

    private Color _forceColor = Color.Black;

    protected int ColorIndex => _colorIndex;

    public void SetForceColor(Color value)
    {
        _forceColor = value;
    }

    protected virtual new void CreateAll()
    {
        if(Model == null) Model = new M();
        if(ViewModel == null) ViewModel = new VM();
    }

    protected override void InitModel()
    {
        base.InitModel();
        Color color;

        if (_forceColor == Color.Black)
        {
            color = Color.ConvertFromUnity(GameplayColors.Instance.ColorPack.Colors[_colorIndex]);
        }
        else
        {
            color = _forceColor;
        }
        
        Model.Initialize(color);
    }

    protected override void InitViewModel()
    {
        base.InitViewModel();
        Color color;

        if (_forceColor == Color.Black)
        {
            color = Color.ConvertFromUnity(GameplayColors.Instance.ColorPack.Colors[_colorIndex]);
        }
        else
        {
            color = _forceColor;
        }

        ViewModel.Initialize(color);
    }

    protected override void InitView()
    {
        base.InitView();
        View.Initialize(ViewModel);
    }
}