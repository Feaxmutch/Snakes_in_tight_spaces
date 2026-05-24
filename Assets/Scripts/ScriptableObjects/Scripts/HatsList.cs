using UnityEngine;

[CreateAssetMenu(fileName = "new hats list", menuName = "create hats list")]
public class HatsList : ScriptableObject
{
    [field : SerializeField] public HatV[] Hats { get; private set; }
}