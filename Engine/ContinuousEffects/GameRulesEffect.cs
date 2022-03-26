namespace Engine.ContinuousEffects
{
    /// <summary>
    /// 613.11. Some continuous effects affect game rules rather than objects.
    /// </summary>
    public abstract class GameRulesEffect : ContinuousEffect
    {
        protected GameRulesEffect(ContinuousEffect effect) : base(effect)
        {
        }

        protected GameRulesEffect(ICardFilter filter, IDuration duration, params Condition[] conditions) : base(filter, duration, conditions)
        {
        }
    }
}
