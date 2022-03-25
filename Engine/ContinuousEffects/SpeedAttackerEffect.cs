namespace Engine.ContinuousEffects
{
    public abstract class SpeedAttackerEffect : ContinuousEffect
    {
        protected SpeedAttackerEffect(ICardFilter filter) : base(filter)
        {
        }

        protected SpeedAttackerEffect(SpeedAttackerEffect effect) : base(effect)
        {
        }
    }
}
