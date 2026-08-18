using System;
using System.Collections.Generic;
using Model;
using Other;
using UnityEngine;
using Vector2Int = Other.Vector2Int;

[RequireComponent(typeof(MeshRenderer))]
public class LevelBackgroundV : MonoBehaviour
{
    [SerializeField] private float _zoomFactor = 1;
    private MeshRenderer _meshRenderer;
    private MaterialScaler _materialScaler;

    private bool _isInit = false;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        SetMaterial(_meshRenderer.material);
        _isInit = true;
    }

    private void OnValidate()
    {
        if (_meshRenderer == null || _materialScaler == null)
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _materialScaler = new(_meshRenderer.sharedMaterial);
        }
    }

    public void SetSize(Vector2Int levelSize)
    {
        if (_isInit == false)
        {
            Awake();
        }
        
        transform.localScale = new Vector3(levelSize.X, 1, levelSize.Y);
        _materialScaler.ScaleMaterial(levelSize.ConvertToUnityInt(), _zoomFactor);
    }

    public void SetPosition(Vector2Int positionOffset, Vector2Int levelSize)
    {
        if (_isInit == false)
        {
            Awake();
        }
        
        if (positionOffset.X.IsInRange(-1,1) == false || positionOffset.Y.IsInRange(-1,1) == false)
        {
            throw new ArgumentOutOfRangeException();
        }

        float positionX = ((float)(levelSize.X - 1) / 2) + (levelSize.X * positionOffset.X);
        float positionY = ((float)(levelSize.Y - 1) / 2) + (levelSize.Y * positionOffset.Y);
        transform.position = new Vector3(positionX, 0, positionY);
    }

    public void SetMaterial(Material material)
    {
        Material materialCopy = new(material);
        _meshRenderer.SetMaterials(new List<Material>() {materialCopy});
        _materialScaler = new(materialCopy);
    }
}
