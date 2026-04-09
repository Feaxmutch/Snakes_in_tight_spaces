using UnityEngine;
using ViewModel;
using System;

[RequireComponent(typeof(MeshRenderer))]
public class ColoredObjectV : DefaultGridObjectV
{
    private ColoredObjectVM _viewModel;
    private MeshRenderer _meshRenderer;

    protected void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Initialize(ColoredObjectVM viewModel)
    {
        _viewModel = viewModel;
        _viewModel.Color.Changed += SetColor;
        _viewModel.Color.InvokeEvent();
        base.Initialize(viewModel);
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