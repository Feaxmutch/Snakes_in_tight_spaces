using UnityEngine;

public class FadebleWindowV : AnimatedWindowV
{
    protected override void OnAnimationChanged(float currentState)
    {
        CanvasGroup.alpha = currentState;
    }
}