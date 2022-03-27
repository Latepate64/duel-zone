namespace Engine.ContinuousEffects
{
    public abstract class CannotAttackPlayersEffect : ContinuousEffect
    {
        protected CannotAttackPlayersEffect(ICardFilter filter, IDuration duration, params Condition[] conditions) : base(filter, duration, conditions)
        {

        }

        protected CannotAttackPlayersEffect(CannotAttackPlayersEffect effect) : base(effect)
        {
        }
    }
}
