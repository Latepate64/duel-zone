using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCannotBeBlockedThisTurnEffect : UntilEndOfTurnEffect, IUnblockableEffect
    {
        public ThisCreatureCannotBeBlockedThisTurnEffect() : base(new TargetFilter())
        {
        }

        public bool Applies(ICard blocker, IGame game)
        {
            return true;
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
