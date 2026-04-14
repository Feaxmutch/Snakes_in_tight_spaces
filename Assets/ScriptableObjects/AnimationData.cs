using UnityEngine;

[CreateAssetMenu(fileName = "new animation", menuName = "create animation")]
public class AnimationData : ScriptableObject
{
    [field : SerializeField] public float StartValue { get; private set; }

    [field : SerializeField] public float EndValue { get; private set; }

    [field : SerializeField] public float Duration { get; private set; }

    [field : SerializeField] public AnimationCurve Curve { get; private set; }

    private void OnValidate()
    {
        Duration = Mathf.Max(Duration, default(float));
    }
}