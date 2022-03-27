namespace Engine.ContinuousEffects
{
    public abstract class ChargerEffect : ContinuousEffect
    {
        protected ChargerEffect(ICardFilter filter, IDuration duration) : base(filter, duration)
        {
        }

        protected ChargerEffect(ChargerEffect effect) : base(effect)
        {
        }
    }
}
