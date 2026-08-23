using Other;

public class AnimationFactory
{
    public Animation Create(AnimationData data)
    {
        Animation animation = new();
        animation.SetDuration(data.Duration);
        animation.SetLimits(data.StartValue, data.EndValue);
        animation.SetCurve(new Curve(data.Curve));
        return animation;
    }
}
