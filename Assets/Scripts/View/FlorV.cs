using System.ComponentModel;
using System.Drawing;
using UnityEngine;

public class FlorV : MonoBehaviour
{
    [Min(0)] [SerializeField] private Vector2Int _size;
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private float _zoomFactor;

    private Material _meshMaterial;

    private void Awake()
    {
        _meshMaterial = _mesh.material; 
    }

    void Start()
    {
        Scale(_size);
    }

    private void OnValidate()
    {
        _meshMaterial = _mesh.sharedMaterial;
        Scale(_size);
    }

    public void Scale(Vector2Int size)
    {
        _size = size;
        gameObject.transform.localScale = new Vector3(size.x, 1, size.y);
        float xScale = size.x / _zoomFactor;
        float yScale = size.y / _zoomFactor;
        _meshMaterial.mainTextureScale = new Vector2(xScale, yScale);
    }
}
