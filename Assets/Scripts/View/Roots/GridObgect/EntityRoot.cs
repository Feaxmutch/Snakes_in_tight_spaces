using Model;
using ViewModel;
using UnityEngine;
using Color = Other.Color;

public class EntityRoot<M, VM, V> : GridObjectRoot<M, VM, V> where M : Entity, new() where VM : EntityVM, new() where V : EntityV 
{
    [SerializeField] private byte _groopId;

    protected int GroopId => _groopId;

    public void SetForceGroopId(byte groopId)
    {
        _groopId = groopId;
    }

    protected virtual new void CreateAll()
    {
        if(Model == null) Model = new M();
        if(ViewModel == null) ViewModel = new VM();
    }

    protected override void InitModel()
    {
        base.InitModel();
        Model.Initialize(_groopId);
    }

    protected override void InitViewModel()
    {
        base.InitViewModel();
        ViewModel.Initialize(_groopId);
    }

    protected override void InitView()
    {
        base.InitView();
        View.Initialize(ViewModel, GameplayMaterials.Instance.Chapters[ChapterId]);
    }
}