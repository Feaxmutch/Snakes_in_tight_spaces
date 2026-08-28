using UnityEngine;
using Other;

public class Curve : ICurve
{
    private AnimationCurve _curve;

    public Curve(AnimationCurve curve)
    {
        _curve = curve;
    }

    public float Evaluate(float time) => _curve.Evaluate(time);
}