using Model;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "new level", menuName = "create level")]
public class LevelData : ScriptableObject
{
    [field : SerializeField] public string Name { get; private set; }

    [field : SerializeField] public Vector2Int Size { get; private set; }

    [field : SerializeField] public LevelRoot LevelPrefab { get; private set; }

    [field : SerializeField] public float SnakesSpeed { get; private set; }
}