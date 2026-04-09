using UnityEngine;
using Model;
using ViewModel;
using Other;

public abstract class GridObjectRoot<M, VM, V> : MonoBehaviour where M : GridObject, new() where VM : GridObjectVM, new() where V : DefaultGridObjectV
{
    [field : SerializeField] public V View { get; private set; }

    public M Model { get; protected set; }

    protected VM ViewModel { get; set; }

    public virtual void Compose(M model = null, VM viewModel = null)
    {
        CreateModel();
        CreateViewModel(model);
        InitializeView(viewModel);
    }

    public virtual void Compose()
    {
        Compose(null, null);
    }

    protected virtual void CreateModel()
    {
        GridObjectFactory factory = new();
        Model = factory.Create<M>();
    }

    protected virtual void CreateViewModel(M model = null)
    {
        ViewModel = new();

        if (model != null)
        {
            Model = model;
        }

        ViewModel.Initialize(Model);
    }

    protected virtual void InitializeView(VM viewModel = null)
    {
        if (viewModel != null)
        {
            ViewModel = viewModel;
        }

        View.Initialize(ViewModel);
    }
}