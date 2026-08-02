using ViewModel;
using UnityEngine;

public class ExitV : EntityV
{
    [SerializeField] private DoorV[] _doors;

    private ExitVM _viewModel;
    private Vector3 _basePosition;

    private void Awake()
    {
        _basePosition = transform.position;
    }

    public void Initialize(ExitVM viewModel)
    {
        _viewModel = viewModel;
        _viewModel.OpenProgres.Changed += UpdateProgres;
        UpdateProgres(_viewModel.OpenProgres.Value);
    }

    protected override void Subscribe()
    {
        base.Subscribe();

        if (IsInitialized)
        {
            _viewModel.OpenProgres.Changed += UpdateProgres;
        }
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();

        if (IsInitialized)
        {
            _viewModel.OpenProgres.Changed -= UpdateProgres;
        }
    }

    private void UpdateProgres(float value)
    {
        foreach (var door in _doors)
        {
            door.SetPositionOffset(value);
        }
    }

    protected override void SetMaterial(Material material)
    {
        base.SetMaterial(material);

        foreach (var door in _doors)
        {
            door.SetMaterial(material);
        }
    }
}