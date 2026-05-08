using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadebleWindowV : AnimatedWindowV
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>(); 
    }

    protected override void OnAnimationChanged(float currentState)
    {
        _canvasGroup.alpha = currentState;
    }
}