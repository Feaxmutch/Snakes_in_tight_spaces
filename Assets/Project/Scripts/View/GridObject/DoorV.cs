using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class DoorV : MonoBehaviour
{

    private MeshRenderer _meshRenderer;
    private Vector3 _basePosition;
    private Vector3 _localDirection;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _basePosition = transform.localPosition;
        _localDirection = transform.localRotation * Vector3.forward;
    }

    public void SetPositionOffset(float value)
    {
        Vector3 newOffset = _localDirection * value;
        transform.localPosition = _basePosition + newOffset;
    }

    public void SetMaterial(Material material)
    {
        if (_meshRenderer == null)
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        _meshRenderer.material = material;
    }
}
