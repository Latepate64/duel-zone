namespace Engine.ContinuousEffects
{
    public abstract class CannotAttackEffect : GameRulesEffect
    {
        protected CannotAttackEffect(CannotAttackEffect effect) : base(effect)
        {
        }

        protected CannotAttackEffect(ICardFilter filter, params Condition[] conditions) : base(filter, conditions)
        {
        }
    }
}
