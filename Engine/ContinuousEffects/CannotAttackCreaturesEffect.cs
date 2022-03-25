namespace Engine.ContinuousEffects
{
    public abstract class CannotAttackCreaturesEffect : ContinuousEffect
    {
        protected CannotAttackCreaturesEffect(ICardFilter filter, params Condition[] conditions) : base(filter, conditions)
        {
        }

        protected CannotAttackCreaturesEffect(CannotAttackCreaturesEffect effect) : base(effect)
        {
        }
    }
}
