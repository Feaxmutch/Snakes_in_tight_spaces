using UnityEngine;


public class FlorV : MonoBehaviour
{
    [Min(0)] [SerializeField] private Vector2Int _size;
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private float _zoomFactor;

    private MaterialScaler _materialScaler;

    private void Awake()
    {
        if (_mesh?.sharedMaterial != null)
        {
            _materialScaler = new(_mesh.material);
        }
    }

    void Start()
    {
        ScaleMaterial(_size);
    }

    private void OnValidate()
    {
        if (_mesh?.sharedMaterial != null)
        {
            _materialScaler = new(_mesh.sharedMaterial);
            ScaleMaterial(_size);
        }
    }

    public void ScaleMaterial(Vector2Int size)
    {
        _size = size;
        gameObject.transform.localScale = new Vector3(size.x, 1, size.y);
        _materialScaler.ScaleMaterial(size, _zoomFactor);
    }
}
