using UnityEngine;

[CreateAssetMenu(fileName = "new Colors Pack", menuName = "create Colors Pack")]
public class ColorPack : ScriptableObject
{
    [field : SerializeField] public Color[] Colors { get; private set; }

    [field : SerializeField] public int GoldColorIndex { get; private set; }

    [field : SerializeField] public int LockedColorIndex { get; private set; }
}