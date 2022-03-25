namespace Engine.ContinuousEffects
{
    public abstract class AttacksIfAbleEffect : ContinuousEffect
    {
        protected AttacksIfAbleEffect(ICardFilter filter) : base(filter)
        {
        }

        protected AttacksIfAbleEffect(AttacksIfAbleEffect effect) : base(effect)
        {
        }
    }
}
