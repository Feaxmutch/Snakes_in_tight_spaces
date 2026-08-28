using UnityEngine; 

[CreateAssetMenu(fileName = "new materials", menuName = "create chapter materials")]
public class StyleMaterials : ScriptableObject
{
    [field : SerializeField] public Material Wall { get; private set; }

    [field : SerializeField] public Material Flor { get; private set; }

    [field : SerializeField] public Material GoldApple { get; private set; }

    [field : SerializeField] public Material LockedApple { get; private set; }

    [field : SerializeField] public Material[] Entites { get; private set; }
}
