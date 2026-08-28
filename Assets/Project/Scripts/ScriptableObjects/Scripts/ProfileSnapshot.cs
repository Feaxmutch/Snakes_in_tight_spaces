using UnityEngine;
[CreateAssetMenu(fileName = "new profile snapshot", menuName = "create profile")]
public class ProfileSnapshot : ScriptableObject
{
    [field : SerializeField] public string Name  { get; private set; }

    [field : SerializeField] public int LastLevel {get; private set; }

    [field : SerializeField] public int HatID { get; private set; }
}