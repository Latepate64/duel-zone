namespace Engine.ContinuousEffects
{
    public abstract class CannotAttackPlayersEffect : ContinuousEffect
    {
        protected CannotAttackPlayersEffect(ICardFilter filter, params Condition[] conditions) : base(filter, conditions)
        {

        }

        protected CannotAttackPlayersEffect(CannotAttackPlayersEffect effect) : base(effect)
        {
        }
    }
}
