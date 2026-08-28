using UnityEngine;
using Vector2Int = Other.Vector2Int;

public abstract class GridObjectV : MonoBehaviour
{
    public byte ChapterId { get; private set; }

    protected float YOffset { get; } = 0;

    public bool IsInitialized { get; private set; } = false;

    public void Initialize(byte chapterId)
    {
        ChapterId = chapterId;
        IsInitialized = true;
    }

    protected void UpdatePosition(Vector2Int position)
    {
        float x = position.X;
        float z = position.Y;
        transform.position = new Vector3(x, YOffset, z);
    }

    protected void UpdatePosition(Vector2 position)
    {
        float x = position.x;
        float z = position.y;
        transform.position = new Vector3(x, YOffset, z);
    }

    protected void OnDestroyed()
    {
        if(this == null || gameObject == null) return; //Разобраться почему становится null до вызова
        Destroy(gameObject);
    }
}