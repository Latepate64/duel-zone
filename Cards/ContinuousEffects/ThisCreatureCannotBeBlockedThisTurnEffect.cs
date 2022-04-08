using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCannotBeBlockedThisTurnEffect : UntilEndOfTurnEffect, IUnblockableEffect
    {
        public ThisCreatureCannotBeBlockedThisTurnEffect() : base()
        {
        }

        public ThisCreatureCannotBeBlockedThisTurnEffect(ThisCreatureCannotBeBlockedThisTurnEffect effect) : base(effect)
        {
        }

        public bool Applies(ICard attacker, ICard blocker, IGame game)
        {
            return IsSourceOfAbility(attacker, game);
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCannotBeBlockedThisTurnEffect(this);
        }

        public override string ToString()
        {
            return "This creature can't be blocked this turn.";
        }
    }
}
