using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class WallV : DefaultGridObjectV
{
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material = GameplayMaterials.Instance.Chapters[ChapterId].Wall;
    }
}