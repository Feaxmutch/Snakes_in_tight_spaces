using UnityEngine;
using ViewModel;

[RequireComponent(typeof(MeshRenderer))]
public class ColoredObjectV : DefaultGridObjectV
{
    private ColoredObjectVM _viewModel;
    private MeshRenderer _meshRenderer;

    protected void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        if (IsInitialized)
        {
            _viewModel.Color.Changed += SetColor;
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        if (IsInitialized)
        {
            _viewModel.Color.Changed -= SetColor;
        }
    }

    public void Initialize(ColoredObjectVM viewModel)
    {
        _viewModel = viewModel;
        _viewModel.Color.Changed += SetColor;
        _viewModel.Color.InvokeEvent();
    }
    private void SetColor(Other.Color color)
    {
        if (_meshRenderer == null)
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        _meshRenderer.material.color = Other.Color.ConvertToUnity(color);
    }

}