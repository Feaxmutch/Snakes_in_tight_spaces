using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DepthOfFieldService : MonoBehaviour
{
    [SerializeField] private PostProcessVolume _volume;
    [Range(0f, 32f)] [SerializeField] private float _value = 32f;

    private DepthOfField _effect;

    private void Awake()
    {
        PostProcessProfile profile = _volume.profile; 

        if (profile.TryGetSettings(out _effect))
        {
            _effect.enabled.overrideState = true;
            _effect.enabled.value = true;
            _effect.aperture.overrideState = true;
        }
        else
        {
            Debug.LogWarning("Компонент DepthOfField не найден в профиле!");
        }
    }

    private void Update()
    {
        if (_effect != null)
        {
            _effect.aperture.value = _value;
        }
    }

    public void SetValue(float value)
    {
        _value = value;
    }
}