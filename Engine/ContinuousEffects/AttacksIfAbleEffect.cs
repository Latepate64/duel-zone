namespace Engine.ContinuousEffects
{
    public abstract class AttacksIfAbleEffect : ContinuousEffect
    {
        protected AttacksIfAbleEffect(ICardFilter filter, IDuration duration) : base(filter, duration)
        {
        }

        protected AttacksIfAbleEffect(AttacksIfAbleEffect effect) : base(effect)
        {
        }
    }
}
