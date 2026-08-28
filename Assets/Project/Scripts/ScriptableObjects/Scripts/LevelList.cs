using UnityEngine;

[CreateAssetMenu(fileName = "new level list", menuName = "create list")]
public class LevelList : ScriptableObject
{
    [field : SerializeField] public LevelData[] Levels { get; private set; }
}