namespace Engine.ContinuousEffects
{
    public abstract class ChargerEffect : ContinuousEffect
    {
        protected ChargerEffect(ICardFilter filter) : base(filter)
        {
        }

        protected ChargerEffect(ChargerEffect effect) : base(effect)
        {
        }
    }
}
