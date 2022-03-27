namespace Engine.ContinuousEffects
{
    public abstract class CannotAttackCreaturesEffect : ContinuousEffect
    {
        protected CannotAttackCreaturesEffect(ICardFilter filter, IDuration duration, params Condition[] conditions) : base(filter, duration, conditions)
        {
        }

        protected CannotAttackCreaturesEffect(CannotAttackCreaturesEffect effect) : base(effect)
        {
        }
    }
}
