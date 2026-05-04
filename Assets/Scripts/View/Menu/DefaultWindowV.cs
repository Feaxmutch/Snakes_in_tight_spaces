using UnityEngine;
using ViewModel;

[RequireComponent(typeof(RectTransform))]
public class DefaultWindowV : AnimatedWindowV
{
    [SerializeField] private Vector2 _positionMultiplyer;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    protected override void OnAnimationChanged(float currentState)
    {
        _rectTransform.anchoredPosition = _positionMultiplyer * currentState;
    }
}