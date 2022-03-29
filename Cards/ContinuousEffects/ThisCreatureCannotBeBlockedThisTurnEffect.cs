using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCannotBeBlockedThisTurnEffect : UnblockableEffect
    {
        public ThisCreatureCannotBeBlockedThisTurnEffect() : base(null, new Durations.UntilTheEndOfTheTurn(), new CardFilters.BattleZoneCreatureFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCannotBeBlockedThisTurnEffect();
        }

        public override string ToString()
        {
            return "This creature can't be blocked this turn.";
        }
    }
}
