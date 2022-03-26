namespace Engine.ContinuousEffects
{
    public abstract class SpeedAttackerEffect : ContinuousEffect
    {
        protected SpeedAttackerEffect(ICardFilter filter, IDuration duration) : base(filter, duration)
        {
        }

        protected SpeedAttackerEffect(SpeedAttackerEffect effect) : base(effect)
        {
        }
    }
}
