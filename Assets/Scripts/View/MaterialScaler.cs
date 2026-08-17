
using UnityEngine;

public class MaterialScaler
{
    private Material _material;

    public MaterialScaler(Material material)
    {
        _material = material;
    }

    public void ScaleMaterial(Vector2Int size, float zoomFactor)
    {
        float xScale = size.x / zoomFactor;
        float yScale = size.y / zoomFactor;
        _material.mainTextureScale = new Vector2(xScale, yScale);
    }
}
