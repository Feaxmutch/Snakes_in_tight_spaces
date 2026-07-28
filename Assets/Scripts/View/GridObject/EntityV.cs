using UnityEngine;
using ViewModel;

[RequireComponent(typeof(MeshRenderer))]
public class EntityV : DefaultGridObjectV
{
    private EntityVM _viewModel;
    private MeshRenderer _meshRenderer;

    protected ChapterMaterials Materials { get; private set; }

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Initialize(EntityVM viewModel, ChapterMaterials materials)
    {
        _viewModel = viewModel;
        Materials = materials;
        SetDefaultMaterial();
    }
    protected void SetMaterial(Material material)
    {
        if (_meshRenderer == null)
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        _meshRenderer.material = material;
    }

    protected virtual void SetDefaultMaterial()
    {
        SetMaterial(Materials.Entites[_viewModel.GroopId]);
    }
}